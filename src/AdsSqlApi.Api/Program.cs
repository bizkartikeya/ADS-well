using AdsSqlApi.Infrastructure;
using AdsSqlApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
// DbContext is registered in Infrastructure.AddInfrastructure

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        var db = services.GetRequiredService<AdsDatabaseContext>();
        await AdsDatabaseContextInitializer.EnsureTablesCreatedAsync(db);

        var conn = db.Database.GetDbConnection().ConnectionString;
        logger.LogInformation("ADS database initialized. Env: {Env}, Connection: {Conn}", builder.Environment.EnvironmentName, conn);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while initializing the ADS database.");
        throw;
    }
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGet("/", () => Results.Redirect("/swagger"));
app.MapControllers();

app.Run();
