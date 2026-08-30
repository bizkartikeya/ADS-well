using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdsSqlApi.Application.Dtos;
using AdsSqlApi.Application.Queries;
using AdsSqlApi.Application.Abstractions.Cqrs;
using Microsoft.AspNetCore.Mvc;

namespace AdsSqlApi.Api.Controllers
{
    [ApiController]
    [Route("api/well-tests")]
    public class WellTestController : ControllerBase
    {
        private readonly IQueryHandler<GetWellTestsBetweenDateRangeExclusiveQuery, IEnumerable<WellTestDto>> _handler;

        public WellTestController(
            IQueryHandler<GetWellTestsBetweenDateRangeExclusiveQuery, IEnumerable<WellTestDto>> handler)
        {
            _handler = handler;
        }

        public class GetWellTestsBetweenDateRangeExclusiveRequest
        {
            public string WorkflowType { get; set; }
            public string PadName { get; set; }
            public DateTimeOffset? StartDate { get; set; }
            public DateTimeOffset? EndDate { get; set; }
        }

        // POST api/well-tests/get_well_test_between_date_range_exclusive
        [HttpPost("get_well_test_between_date_range_exclusive")]
        public async Task<IActionResult> GetWellTestBetweenDateRangeExclusive(
            [FromBody] GetWellTestsBetweenDateRangeExclusiveRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request body is required.");
            }

            if (string.IsNullOrWhiteSpace(request.WorkflowType))
            {
                return BadRequest("WorkflowType is required.");
            }

            var query = new GetWellTestsBetweenDateRangeExclusiveQuery(
                request.WorkflowType,
                request.PadName,
                request.StartDate,
                request.EndDate);

            var results = await _handler.HandleAsync(query);
            return Ok(results);
        }
    }
}
