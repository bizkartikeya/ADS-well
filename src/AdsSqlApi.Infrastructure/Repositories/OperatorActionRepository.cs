using System.Collections.Generic;
using System.Linq;
using AdsSqlApi.Infrastructure.Persistence;
using AdsSqlApi.Infrastructure.Persistence.AdsModels;

namespace AdsSqlApi.Infrastructure.Repositories
{
    public class OperatorActionRepository : IOperatorActionRepository
    {
        private readonly AdsDatabaseContext _context;

        public OperatorActionRepository(AdsDatabaseContext context)
        {
            _context = context;
        }

        public IQueryable<OperatorAction> BuildOperatorActionQuery(IEnumerable<int> workflowTypeIds)
        {
            // Build a query that finds OperatorActionIds from mapping table for provided workflowTypeIds
            var mappedOperatorIds = _context.OPERATOR_ACTION_WORKFLOW_MAPPING
                .Where(m => workflowTypeIds.Contains(m.WorkflowTypeId))
                .Select(m => m.OperatorActionId);

            // Build and return the operator action query without executing it
            var query = _context.OPERATOR_ACTION
                .Where(op => mappedOperatorIds.Contains(op.OperatorActionId));

            return query;
        }
    }
}
