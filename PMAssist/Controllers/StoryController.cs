using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMAssist.Managers;
using PMAssist.Models;

namespace PMAssist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly ILogger<StoryController> _logger;

        public StoryController(ILogger<StoryController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddActivity(ActivityRequestModel activityRequestModel)
        {
            var storyManager = new StoryManager();
            await storyManager.AddActivity(activityRequestModel);
            return Ok();
        }

        [HttpPost]
        public async Task UpdateActivity(ActivityRequestModel activityRequestModel)
        {
            Ok();
        }

        [HttpPost]
        public async Task DeleteActivity(ActivityRequestModel activityRequestModel)
        {
            Ok();
        }

        [HttpPost]
        public async Task AddStory(ActivityRequestModel activityRequestModel)
        {
            Ok();
        }

        [HttpPost]
        public async Task UpdateStory(ActivityRequestModel activityRequestModel)
        {
            Ok();
        }

        [HttpPost]
        public async Task DeleteStory(ActivityRequestModel activityRequestModel)
        {
            Ok();
        }

        [HttpPost]
        public async Task AddBug(ActivityRequestModel activityRequestModel)
        {
            Ok();
        }

        [HttpPost]
        public async Task UpdateBug(ActivityRequestModel activityRequestModel)
        {
            Ok();
        }

        [HttpPost]
        public async Task DeleteBug(ActivityRequestModel activityRequestModel)
        {
            Ok();
        }
    }
}
