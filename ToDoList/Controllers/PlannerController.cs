using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlannerController : ControllerBase
    {
        private readonly IPlannerService _plannerService;

        public PlannerController(IPlannerService plannerService)
        {
            _plannerService = plannerService;
        }

        [HttpGet]
        public ActionResult<DailyPlan> GetNotes(int id)
        {
            return _plannerService.Notify(id).Result;
        }

    }
}
 