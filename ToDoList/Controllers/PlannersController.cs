using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDoList.Commands.Plan.Create;
using ToDoList.Commands.Plan.Delete;
using ToDoList.Commands.Plan.Update;
using ToDoList.Queries.Plan.Get;

namespace ToDoList.Controllers
{
    [Route("api/planners")]
    [ApiController]
    public class PlannersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlannersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _mediator.Send(new GetPlansQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(CreatePlanCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update(UpdatePlanCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePlanCommand request)
        {
            await _mediator.Send(request);
            
            return Ok();
        }
    }
}
 