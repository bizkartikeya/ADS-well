using System;
using System.Linq;
using AdsSqlApi.Infrastructure.Persistence;
using AdsSqlApi.Infrastructure.Persistence.AdsModels;

namespace AdsSqlApi.Infrastructure.Repositories
{
    public class WellTestRepository : IWellTestRepository
    {
        private readonly AdsDatabaseContext _context;

        public WellTestRepository(AdsDatabaseContext context)
        {
            _context = context;
        }

        public IQueryable<WellTestView> BuildWellTestBetweenDateRangeExclusiveQuery(
            string workflowType,
            string padName,
            DateTimeOffset? startDate,
            DateTimeOffset? endDate)
        {
            var query = _context.WELL_TEST_VIEW.AsQueryable();

            if (!string.IsNullOrWhiteSpace(workflowType))
            {
                query = query.Where(wt => wt.WellTestType == workflowType);
            }

            if (!string.IsNullOrWhiteSpace(padName))
            {
                query = query.Where(wt => wt.PadName == padName);
            }

            if (startDate.HasValue)
            {
                query = query.Where(wt => wt.StartDate.HasValue && wt.StartDate.Value > startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(wt => wt.EndDate.HasValue && wt.EndDate.Value < endDate.Value);
            }

            return query;
        }
    }
}
