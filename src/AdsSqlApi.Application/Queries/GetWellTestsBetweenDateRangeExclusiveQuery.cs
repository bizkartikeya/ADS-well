using System;
using System.Collections.Generic;
using AdsSqlApi.Application.Abstractions.Cqrs;
using AdsSqlApi.Application.Dtos;

namespace AdsSqlApi.Application.Queries
{
    public class GetWellTestsBetweenDateRangeExclusiveQuery : IQuery<IEnumerable<WellTestDto>>
    {
        public GetWellTestsBetweenDateRangeExclusiveQuery(
            string workflowType,
            string padName,
            DateTimeOffset? startDate,
            DateTimeOffset? endDate)
        {
            WorkflowType = workflowType;
            PadName = padName;
            StartDate = startDate;
            EndDate = endDate;
        }

        public string WorkflowType { get; }
        public string PadName { get; }
        public DateTimeOffset? StartDate { get; }
        public DateTimeOffset? EndDate { get; }
    }
}
