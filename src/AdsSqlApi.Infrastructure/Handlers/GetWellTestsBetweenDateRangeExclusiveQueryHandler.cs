using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdsSqlApi.Application.Abstractions.Cqrs;
using AdsSqlApi.Application.Dtos;
using AdsSqlApi.Application.Queries;
using AdsSqlApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdsSqlApi.Infrastructure.Handlers
{
    public class GetWellTestsBetweenDateRangeExclusiveQueryHandler
        : IQueryHandler<GetWellTestsBetweenDateRangeExclusiveQuery, IEnumerable<WellTestDto>>
    {
        private readonly IWellTestRepository _repository;

        public GetWellTestsBetweenDateRangeExclusiveQueryHandler(IWellTestRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<WellTestDto>> HandleAsync(
            GetWellTestsBetweenDateRangeExclusiveQuery query,
            CancellationToken cancellationToken = default)
        {
            var builtQuery = _repository
                .BuildWellTestBetweenDateRangeExclusiveQuery(
                    query.WorkflowType,
                    query.PadName,
                    query.StartDate,
                    query.EndDate)
                .Select(wt => new WellTestDto
                {
                    FieldName = wt.FieldName,
                    PadName = wt.PadName,
                    WellName = wt.WellName,
                    PadId = wt.PadId,
                    WellId = wt.WellId,
                    PadType = wt.PadType,
                    Rov = wt.Rov,
                    Port = wt.Port,
                    WellTestType = wt.WellTestType,
                    IsWellActive = wt.IsWellActive,
                    IsPadWTVActive = wt.IsPadWTVActive,
                    IsPadAutoPODSActive = wt.IsPadAutoPODSActive,
                    IsPadInferredDailyActive = wt.IsPadInferredDailyActive,
                    IsPadOperateByPriorityActive = wt.IsPadOperateByPriorityActive,
                    WellTestId = wt.WellTestId,
                    StartDate = wt.StartDate,
                    EndDate = wt.EndDate,
                    CreateDate = wt.CreateDate
                });

            return await builtQuery.ToListAsync(cancellationToken);
        }
    }
}
