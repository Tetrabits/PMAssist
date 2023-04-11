using Microsoft.AspNetCore.Mvc;
using PMAssist.Models.External;
using PMAssist.Models;
using System.Text.Json;

namespace PMAssist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScrumController : ControllerBase
    {
        private readonly ILogger<ScrumController> _logger;

        public ScrumController(ILogger<ScrumController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string currentDate)
        {
            return Task.Run(() =>
            {

                var content = System.IO.File.ReadAllText("D:\\Hariprasad\\Code\\Tetrabits\\PMAssist\\ProjectData.json");

                var project = JsonSerializer.Deserialize<Project>(content);
                var today = Convert.ToDateTime(currentDate);

                var projectEx = new ProjectEx
                {
                    Name = project.Name,
                    SprintDuration = project.SprintDuration
                };

                var sprint = project.Sprints.FirstOrDefault(n => n.StartsOn <= today && n.EndsOn >= today);

                if (sprint == null)
                {
                    return Ok(projectEx);
                }
                else
                {
                    projectEx.StartsOn = sprint.StartsOn;
                    projectEx.EndsOn = sprint.EndsOn;
                    //projectEx.Stories = sprint.Stories.Select(n => new StoryEx
                    //{
                    //    Id = n.ID,
                    //    Points = n.Points,
                    //});
                    projectEx.Bugs = sprint.Bugs.Select(n => new BugEx
                    {
                        Id = n.ID,
                        Rca = n.RCA,
                    });
                }

                foreach (var user in sprint.Users)
                {
                    var activities = user.Activities.Where(n => n.Status != "Completed")
                        .Select(n => new ActivityEx
                        {
                            ClosedOn = n.ClosedOn,
                            CreatedOn = n.CreatedOn,
                            Client = n.Client,
                            Id = n.ID,
                            LinkID = n.LinkID,
                            Plan = n.Plan,
                            Status = n.Status,
                            //TotalSpent = n.Actuals.Sum(n => n.Value),
                            Type = n.Type,
                            What = n.What
                        });
                    projectEx.Users.Add(new UserEx
                    {
                        Name = user.Name,
                        YesterdayActivities = activities.Where(n => n.CreatedOn.Date < today.Date),
                        Activities = activities.Where(n => n.CreatedOn.Date == today.Date),
                        FutureActivities = activities.Where(n => n.CreatedOn.Date > today.Date),
                    });

                }
                return Ok(projectEx);

            }).GetAwaiter().GetResult();
        }
    }
}