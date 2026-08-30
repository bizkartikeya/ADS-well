using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdsSqlApi.Application.Dtos;
using AdsSqlApi.Application.Queries;
using AdsSqlApi.Application.Abstractions.Cqrs;
using AdsSqlApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdsSqlApi.Infrastructure.Handlers
{
    public class GetOperatorActionsQueryHandler : IQueryHandler<GetOperatorActionsQuery, IEnumerable<OperatorActionDto>>
    {
        private readonly IOperatorActionRepository _repository;

        public GetOperatorActionsQueryHandler(IOperatorActionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OperatorActionDto>> HandleAsync(GetOperatorActionsQuery query, CancellationToken cancellationToken = default)
        {
            // Use repository to build the query (does not execute) and project to DTO
            var builtQuery = _repository.BuildOperatorActionQuery(query.WorkflowTypeIds)
                .Select(op => new OperatorActionDto
                {
                    OperatorActionId = op.OperatorActionId,
                    Name = op.Name,
                    Action = op.Action,
                    Comment = op.Comment
                });

            var list = await builtQuery.ToListAsync(cancellationToken);
            return list;
        }
    }
}
