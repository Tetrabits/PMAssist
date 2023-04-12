using Microsoft.AspNetCore.Mvc;
using PMAssist.Managers;
using PMAssist.Models.External;

namespace PMAssist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private ProjectManager projectManager;

        public ProjectController(ILogger<ProjectController> logger)
        {

            _logger = logger;
            projectManager = new ProjectManager();

        }
        
        /// <summary>
        /// Get all the project details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Task.Run(async () =>
            {
                var projects = await projectManager.GetProjects();
                return projects;
            });

            return Ok(result);
        }

        [HttpGet]
        [Route("getscrumkey")]
        public async Task<IActionResult> GetScrumKey(string projectKey, string currentDate)
        {
            var result = await Task.Run(async () =>
            {
                var content = await projectManager.GetSprintKey(projectKey, DateTime.Parse(currentDate));
                return $"{{\"name\":\"{content}\"}}";
            });

            return Ok(result);
        }
    }
}