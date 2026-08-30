using System.Collections.Generic;
using AdsSqlApi.Application.Dtos;
using AdsSqlApi.Application.Abstractions.Cqrs;

namespace AdsSqlApi.Application.Queries
{
    public class GetOperatorActionsQuery : IQuery<IEnumerable<OperatorActionDto>>
    {
        public GetOperatorActionsQuery(IEnumerable<int> workflowTypeIds)
        {
            WorkflowTypeIds = workflowTypeIds;
        }

        public IEnumerable<int> WorkflowTypeIds { get; }
    }
}
