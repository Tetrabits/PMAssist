using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace PMAssist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataAccessController : ControllerBase
    {
        DataAccessRepository dr = new DataAccessRepository();

        [HttpGet, Route("GetAllData")]
        public async Task<IActionResult> GetAllData(string token, string url)
        {
            var result = await dr.GetAll(token, url);
            return Ok(result);
        }

        [HttpGet, Route("GetData")]
        public async Task<IActionResult> GetData(string token, string url, string uid)
        {
            var result = await dr.GetData(token, url, uid);
            return Ok(result);
        }

        [HttpPost, Route("PostData")]
        public async Task<IActionResult> PostData(string token, string url, string data)
        {
            var result = await dr.PostData(token, url, data);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> PutData(string token, string url, string data)
        {
            var result = await dr.PutData(token, url, data);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> PatchData(string token, string url, string data)
        {
            var result = await dr.PatchData(token, url, data);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteData(string token, string url)
        {
            var result = await dr.DeleteData(token, url);
            return Ok(result);
        }
    }
}