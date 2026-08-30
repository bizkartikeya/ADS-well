using System;
using System.Linq;
using AdsSqlApi.Infrastructure.Persistence.AdsModels;

namespace AdsSqlApi.Infrastructure.Repositories
{
    public interface IWellTestRepository
    {
        IQueryable<WellTestView> BuildWellTestBetweenDateRangeExclusiveQuery(
            string workflowType,
            string padName,
            DateTimeOffset? startDate,
            DateTimeOffset? endDate);
    }
}
