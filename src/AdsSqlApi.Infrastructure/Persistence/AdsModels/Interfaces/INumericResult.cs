namespace AdsSqlApi.Infrastructure.Persistence.AdsModels.Interfaces
{
    public interface INumericResult
    {
        string Parameter { get; set; }
        double? Value { get; set; }
    }
}
