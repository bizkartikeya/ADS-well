using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdsSqlApi.Infrastructure.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AdsSqlApi.Application.Queries;
using AdsSqlApi.Application.Dtos;
using AdsSqlApi.Application.Abstractions.Cqrs;

namespace AdsSqlApi.Api.Controllers
{
    [ApiController]
    [Route("api/operator-actions")]
    public class OperatorActionController : ControllerBase
    {
        private readonly IQueryHandler<GetOperatorActionsQuery, System.Collections.Generic.IEnumerable<OperatorActionDto>> _handler;

        public OperatorActionController(IQueryHandler<GetOperatorActionsQuery, System.Collections.Generic.IEnumerable<OperatorActionDto>> handler)
        {
            _handler = handler;
        }

        // POST api/operator-actions/get_operatior_action
        [HttpPost("get_operatior_action")]
        public async Task<IActionResult> GetOperatiorAction([FromBody] int[] workflowTypeID)
        {
            if (workflowTypeID == null || workflowTypeID.Length == 0)
                return BadRequest("workflowTypeID must be a non-empty array of integers.");

            var q = new GetOperatorActionsQuery(workflowTypeID);
            var results = await _handler.HandleAsync(q);
            return Ok(results);
        }
    }
}
