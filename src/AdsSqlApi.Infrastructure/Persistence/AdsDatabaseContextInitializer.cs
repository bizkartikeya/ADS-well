using System.Data;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace AdsSqlApi.Infrastructure.Persistence;

public static class AdsDatabaseContextInitializer
{
    private static readonly Regex BatchSeparatorRegex =
        new(@"^\s*GO\s*;?\s*$", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);

    private static readonly Regex CreateTableRegex =
        new(@"CREATE\s+TABLE\s+(?<name>(?:\[[^\]]+\]\.)?\[[^\]]+\])", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    private static readonly Regex TableScopedStatementRegex =
        new(@"(?:CREATE\s+(?:UNIQUE\s+)?INDEX\s+\[[^\]]+\]\s+ON|ALTER\s+TABLE)\s+(?<name>(?:\[[^\]]+\]\.)?\[[^\]]+\])", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public static async Task EnsureTablesCreatedAsync(
        AdsDatabaseContext context,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(context);

        var creator = context.GetService<IRelationalDatabaseCreator>();

        if (!await creator.ExistsAsync(cancellationToken).ConfigureAwait(false))
        {
            await creator.CreateAsync(cancellationToken).ConfigureAwait(false);
        }

        var mappedTables = context.Model.GetEntityTypes()
            .Where(entityType => entityType.GetTableName() is not null)
            .Select(entityType => ToTableIdentifier(
                entityType.GetSchema() ?? "dbo",
                entityType.GetTableName()!))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        var existingTables = await GetExistingTablesAsync(context, cancellationToken).ConfigureAwait(false);
        var missingTables = mappedTables
            .Where(table => !existingTables.Contains(table))
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        if (missingTables.Count == 0)
        {
            return;
        }

        await ExecuteMissingTableScriptAsync(context, missingTables, cancellationToken).ConfigureAwait(false);
    }

    private static async Task<HashSet<string>> GetExistingTablesAsync(
        DbContext context,
        CancellationToken cancellationToken)
    {
        var existingTables = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var connection = context.Database.GetDbConnection();
        var shouldClose = connection.State == ConnectionState.Closed;

        if (shouldClose)
        {
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        }

        try
        {
            await using var command = connection.CreateCommand();
            command.CommandText = """
                SELECT TABLE_SCHEMA, TABLE_NAME
                FROM INFORMATION_SCHEMA.TABLES
                WHERE TABLE_TYPE = 'BASE TABLE'
                """;

            await using var reader = await command.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false);

            while (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
            {
                existingTables.Add(ToTableIdentifier(reader.GetString(0), reader.GetString(1)));
            }
        }
        finally
        {
            if (shouldClose)
            {
                await connection.CloseAsync().ConfigureAwait(false);
            }
        }

        return existingTables;
    }

    private static async Task ExecuteMissingTableScriptAsync(
        AdsDatabaseContext context,
        HashSet<string> missingTables,
        CancellationToken cancellationToken)
    {
        var createScript = context.Database.GenerateCreateScript();
        var createdTables = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var batch in SplitBatches(createScript))
        {
            var table = GetCreatedTableIdentifier(batch) ?? GetScopedTableIdentifier(batch);

            if (table is null || !missingTables.Contains(table))
            {
                continue;
            }

            await context.Database.ExecuteSqlRawAsync(batch, cancellationToken).ConfigureAwait(false);
            createdTables.Add(table);
        }

        var notCreated = missingTables.Except(createdTables, StringComparer.OrdinalIgnoreCase).ToArray();

        if (notCreated.Length > 0)
        {
            throw new InvalidOperationException(
                $"Unable to create ADS table(s): {string.Join(", ", notCreated)}.");
        }
    }

    private static IEnumerable<string> SplitBatches(string script)
    {
        foreach (var batch in BatchSeparatorRegex.Split(script))
        {
            var trimmed = batch.Trim();

            if (trimmed.Length > 0)
            {
                yield return trimmed;
            }
        }
    }

    private static string? GetCreatedTableIdentifier(string batch)
    {
        var match = CreateTableRegex.Match(batch);
        return match.Success ? NormalizeDelimitedTableName(match.Groups["name"].Value) : null;
    }

    private static string? GetScopedTableIdentifier(string batch)
    {
        var match = TableScopedStatementRegex.Match(batch);
        return match.Success ? NormalizeDelimitedTableName(match.Groups["name"].Value) : null;
    }

    private static string NormalizeDelimitedTableName(string delimitedName)
    {
        var parts = Regex.Matches(delimitedName, @"\[([^\]]+)\]")
            .Select(match => match.Groups[1].Value)
            .ToArray();

        return parts.Length == 1
            ? ToTableIdentifier("dbo", parts[0])
            : ToTableIdentifier(parts[^2], parts[^1]);
    }

    private static string ToTableIdentifier(string schema, string table) => $"{schema}.{table}";
}
