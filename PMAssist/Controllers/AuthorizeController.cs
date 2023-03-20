using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace PMAssist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public AuthorizeController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string uid, string token)
        {

            HttpClient client = new HttpClient();
            string url = $"https://teamthoughtful17matrix-default-rtdb.firebaseio.com/users/{uid}.json";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                if (responseString != "null")
                {
                    var values = JsonSerializer.Deserialize<Dictionary<string, string>>(responseString);
                    if (values != null 
                        && values.ContainsKey("active")
                        && values["active"]=="true")
                    {
                        return Ok($"{{\"token\":\"token\"}}");
                    }
                    else
                    {
                        return Unauthorized("User is not active");
                    }
                    
                }
            }

            return Unauthorized();
        }
    }
}