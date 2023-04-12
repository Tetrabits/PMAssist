﻿using Microsoft.AspNetCore.Mvc;
using PMAssist.Models.External;
using PMAssist.Models;
using System.Text.Json;
using PMAssist.Managers;

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
            var content = await sprintManager.GetSprints(result);
            return Ok(content);
            
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

            var sprint = project.Sprints.FirstOrDefault(n => n.SprintNumber == sprintNumber);
            var date = sprint.StartsOn.ToString("yyyyMMdd");

            var sprintKey = $"{projectKey}{date}";

            var content = await sprintManager.GetSprints(sprintKey);

            content.Name = project.Name;
            content.StartsOn = sprint.StartsOn;
            content.EndsOn = sprint.EndsOn;


            return Ok(content);

        }
    }
}