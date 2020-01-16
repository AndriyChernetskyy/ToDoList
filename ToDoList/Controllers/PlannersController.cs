using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.MediatR.Commands;
using ToDoList.MediatR.Queries;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Route("api/planners")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class PlannersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlannersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-plans")]
        public async Task<IEnumerable<DailyPlan>> GetNotes()
        {
            var plans = await _mediator.Send(new GetPlansQuery());
            
            return plans;
        }

        [HttpPost]
        [Route("create-plan")]
        public async Task<ActionResult<DailyPlan>> Create(CreatePlan request)
        {
            var plan = await _mediator.Send(request);

            return plan;
        }

        [HttpPut]
        [Route("update-plan")]
        public async Task<ActionResult<DailyPlan>> Update(UpdatePlan request)
        {
            var plan = await _mediator.Send(request);
            
            return plan;
        }

        [HttpDelete]
        [Route("delete-plan")]
        public async Task<IActionResult> Delete(DeletePlan request)
        {
            await _mediator.Send(request);
            
            return Ok();
        }
    }
}
 