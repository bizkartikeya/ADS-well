namespace AdsSqlApi.Infrastructure.Persistence.AdsModels.Interfaces
{
    public interface IStringResult
    {
        string Parameter { get; set; }
        string Value { get; set; }
    }
}
