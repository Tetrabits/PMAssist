using PMAssist.Models;
using Microsoft.AspNetCore.Mvc;
using PMAssist.Managers;

namespace PMAssist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaveInformationController : Controller
    {

        [HttpGet]
        public async Task<IEnumerable<EventApi>> GetLeaveinformations(string currentDate)
        {
            var leaveRequestModel = new LeaveRequestModel
            {
                AuthToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjU4ODI0YTI2ZjFlY2Q1NjEyN2U4OWY1YzkwYTg4MDYxMTJhYmU5OWMiLCJ0eXAiOiJKV1QifQ.eyJuYW1lIjoidGVhbSB0aG91Z2h0ZnVsIiwicGljdHVyZSI6Imh0dHBzOi8vbGgzLmdvb2dsZXVzZXJjb250ZW50LmNvbS9hL0FHTm15eGFKZ3NCeWFwbFJZMU9ZRUdhbXdGcFBSeG5obmNLbjFkbmhTN0ZZPXM5Ni1jIiwiaXNzIjoiaHR0cHM6Ly9zZWN1cmV0b2tlbi5nb29nbGUuY29tL3RlYW10aG91Z2h0ZnVsMTdtYXRyaXgiLCJhdWQiOiJ0ZWFtdGhvdWdodGZ1bDE3bWF0cml4IiwiYXV0aF90aW1lIjoxNjc4OTQ3MzA5LCJ1c2VyX2lkIjoiOFdRTkE2alA5WWVJRTJYRGJqMTlBTUNmTGY5MyIsInN1YiI6IjhXUU5BNmpQOVllSUUyWERiajE5QU1DZkxmOTMiLCJpYXQiOjE2Nzg5NDczMDksImV4cCI6MTY3ODk1MDkwOSwiZW1haWwiOiJ0ZWFtdGhvdWdodGZ1bDE3QGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJmaXJlYmFzZSI6eyJpZGVudGl0aWVzIjp7Imdvb2dsZS5jb20iOlsiMTAxNDA2OTE1NjkwMjc3MjAyMjA1Il0sImVtYWlsIjpbInRlYW10aG91Z2h0ZnVsMTdAZ21haWwuY29tIl19LCJzaWduX2luX3Byb3ZpZGVyIjoiZ29vZ2xlLmNvbSJ9fQ.nh0S5RKtBEA1l9o_bfz06QK4M0VS7e-rha4IdHpmDgQggDWVgbqmOMiDqHMdtfrGCJ63LEJo_e0hw-2AUciTpLXaTTQ0i6_eLHPnyVk57BVcD6nolvVL2c6IaNNbFWTjASa8aAPVHg7whFfmfsZKeW13MCle32ZB1MLxwJZw2qmA9uaCkE1xMX6Q98XXBytsBKy0a_4quLFSK6Uja9jTLfupz793wqkGfk3cqqO5FOMmOshiYUp5JSwUXsUgLApzsoMHGZqzEdN3YgQgjWyFygRX99JTTxzPJmbazOSXg68AgjNv5TsBU-emkS08nsBzT1HRuz_dv3JEfrdaOHD9_A",
                UserId = "8WQNA6jP9YeIE2XDbj19AMCfLf93",
                Date = Convert.ToDateTime(currentDate)
            };
            var leaveManager = new LeaveManager();
            var eventList = await leaveManager.GetLeaves(leaveRequestModel);

            return eventList.ToList();
        }

        [HttpPost]
        [Route("getleaves")]
        public async Task<IEnumerable<EventApi>> GetLeaves(LeaveRequestModel leaveRequestModel)
        {

            var leaveManager = new LeaveManager();
            var eventList = await leaveManager.GetLeaves(leaveRequestModel);

            return eventList;
        }

        [HttpPost]
        [Route("addevent")]
        public async Task<IActionResult> AddEvent(LeaveInfo eventApi)
        {
            var leaveManager = new LeaveManager();
            await leaveManager.AddEvent(eventApi);
            return Ok(eventApi);
        }

        [HttpPost]
        [Route("deleteevent")]
        public async Task<IActionResult> DeleteEvent(LeaveInfo eventApi)
        {
            var leaveManager = new LeaveManager();
            await leaveManager.DeleteEvent(eventApi);
            return Ok(eventApi);
        }
    }
}
