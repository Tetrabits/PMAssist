using Microsoft.AspNetCore.Mvc;
using PMAssist.Managers;
using PMAssist.Helpers;

namespace PMAssist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScrumController : ControllerBase
    {
        private readonly ILogger<ScrumController> _logger;
        private ProjectManager projectManager;
        private SprintManager sprintManager;
        
        

        public ScrumController(ILogger<ScrumController> logger)
        {
            _logger = logger;
            projectManager = new();
            sprintManager = new();
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
        [Route("getsprintbykey")]
        public async Task<IActionResult> GetSprintByKey(string projectKey, string sprintKey)
        {
            var projects = await projectManager.GetProjects();
            var project = projects.FirstOrDefault(n => n.ProjectKey == projectKey)??new Models.External.ProjectEx();

            var result = await sprintManager.GetSprint(sprintKey, project);

            return Ok(result);

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