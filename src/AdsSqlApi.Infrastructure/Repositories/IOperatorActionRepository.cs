using System.Collections.Generic;
using System.Linq;
using AdsSqlApi.Infrastructure.Persistence.AdsModels;

namespace AdsSqlApi.Infrastructure.Repositories
{
    public interface IOperatorActionRepository
    {
        /// <summary>
        /// Build an EF Core query that returns OperatorAction records mapped to the provided workflow type ids.
        /// The returned IQueryable is not executed by this method; caller may further shape or execute it.
        /// </summary>
        IQueryable<OperatorAction> BuildOperatorActionQuery(IEnumerable<int> workflowTypeIds);
    }
}
