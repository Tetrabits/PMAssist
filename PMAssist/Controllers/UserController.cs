using Microsoft.AspNetCore.Mvc;
using PMAssist.Interfaces;

namespace PMAssist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        protected IUserManager UserManager;

        public UserController(ILogger<UserController> logger, IUserManager userManager)
        {
            this.logger = logger;
            this.UserManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await UserManager.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            

        }
    }
}
