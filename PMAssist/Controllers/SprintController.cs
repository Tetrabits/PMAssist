using Microsoft.AspNetCore.Mvc;
using PMAssist.Managers;
using PMAssist.Helpers;
using PMAssist.Interfaces;

namespace PMAssist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SprintController : ControllerBase
    {
        private readonly ILogger<SprintController> _logger;
        private ProjectManager projectManager;
        private ISprintManager sprintManager;


        public SprintController(ILogger<SprintController> logger, ISprintManager sprintManager)
        {
            _logger = logger;
            projectManager = new();
            this.sprintManager = sprintManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string projectKey, string currentDate)
        {

            var date = DateTime.Parse(currentDate);
            var result = await projectManager.GetSprintKey(projectKey, date);
            var content = await sprintManager.GetSprint(result, new Models.External.ProjectEx());
            return Ok(content);

        }

        [HttpGet]
        [Route("{sprintKey}")]
        public async Task<IActionResult> GetStories(string sprintKey)
        {
            var stories = await sprintManager.GetStories(sprintKey);
            return Ok(stories);

        }

        [HttpGet]
        [Route("getsprint")]
        public async Task<IActionResult> GetSprint(string projectKey, short sprintNumber)
        {

            var result = await projectManager.GetProjects();

            var project = result.FirstOrDefault(n => n.ProjectKey == projectKey);
            if (project == null)
            {
                return Ok("");
            }

            var sprint = project.Sprints.FirstOrDefault(n => n.Number == sprintNumber);
            var date = sprint.StartsOn.ToString("yyyyMMdd");

            var sprintKey = $"{projectKey}{date}";

            var content = await sprintManager.GetSprint(sprintKey, new Models.External.ProjectEx());

            content.Name = project.Name;
            content.StartsOn = sprint.StartsOn;
            content.EndsOn = sprint.EndsOn;


            return Ok(content);

        }
    }
}