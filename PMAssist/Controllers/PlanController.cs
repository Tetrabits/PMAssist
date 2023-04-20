using Microsoft.AspNetCore.Mvc;
using PMAssist.Interfaces;
using PMAssist.Models;

namespace PMAssist.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly ILogger<PlanController> logger;
        protected IPlanManager PlanManager;

        public PlanController(ILogger<PlanController> logger, IPlanManager planManager)
        {
            this.logger = logger;
            this.PlanManager = planManager;
        }

        [HttpPost]
        [Route("sprint")]
        public async Task<IActionResult> PlanSprint(ActivityRequestModel activityRequestModel)
        {
            await PlanManager.PlanSprint(activityRequestModel);
            return Ok();
        }
    }
}
