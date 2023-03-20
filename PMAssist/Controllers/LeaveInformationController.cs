using PMAssist.Models;
using Microsoft.AspNetCore.Mvc;
using PMAssist.Managers;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace PMAssist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaveInformationController : Controller
    {
        // GET: LeaveInformationController
        [HttpGet]
        public async Task<List<EventApi>> GetLeaveinformations(string currentDate)
        {
            var leaveRequestModel = new LeaveRequestModel
            {
                AuthToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjU4ODI0YTI2ZjFlY2Q1NjEyN2U4OWY1YzkwYTg4MDYxMTJhYmU5OWMiLCJ0eXAiOiJKV1QifQ.eyJuYW1lIjoidGVhbSB0aG91Z2h0ZnVsIiwicGljdHVyZSI6Imh0dHBzOi8vbGgzLmdvb2dsZXVzZXJjb250ZW50LmNvbS9hL0FHTm15eGFKZ3NCeWFwbFJZMU9ZRUdhbXdGcFBSeG5obmNLbjFkbmhTN0ZZPXM5Ni1jIiwiaXNzIjoiaHR0cHM6Ly9zZWN1cmV0b2tlbi5nb29nbGUuY29tL3RlYW10aG91Z2h0ZnVsMTdtYXRyaXgiLCJhdWQiOiJ0ZWFtdGhvdWdodGZ1bDE3bWF0cml4IiwiYXV0aF90aW1lIjoxNjc4OTQ3MzA5LCJ1c2VyX2lkIjoiOFdRTkE2alA5WWVJRTJYRGJqMTlBTUNmTGY5MyIsInN1YiI6IjhXUU5BNmpQOVllSUUyWERiajE5QU1DZkxmOTMiLCJpYXQiOjE2Nzg5NDczMDksImV4cCI6MTY3ODk1MDkwOSwiZW1haWwiOiJ0ZWFtdGhvdWdodGZ1bDE3QGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJmaXJlYmFzZSI6eyJpZGVudGl0aWVzIjp7Imdvb2dsZS5jb20iOlsiMTAxNDA2OTE1NjkwMjc3MjAyMjA1Il0sImVtYWlsIjpbInRlYW10aG91Z2h0ZnVsMTdAZ21haWwuY29tIl19LCJzaWduX2luX3Byb3ZpZGVyIjoiZ29vZ2xlLmNvbSJ9fQ.nh0S5RKtBEA1l9o_bfz06QK4M0VS7e-rha4IdHpmDgQggDWVgbqmOMiDqHMdtfrGCJ63LEJo_e0hw-2AUciTpLXaTTQ0i6_eLHPnyVk57BVcD6nolvVL2c6IaNNbFWTjASa8aAPVHg7whFfmfsZKeW13MCle32ZB1MLxwJZw2qmA9uaCkE1xMX6Q98XXBytsBKy0a_4quLFSK6Uja9jTLfupz793wqkGfk3cqqO5FOMmOshiYUp5JSwUXsUgLApzsoMHGZqzEdN3YgQgjWyFygRX99JTTxzPJmbazOSXg68AgjNv5TsBU-emkS08nsBzT1HRuz_dv3JEfrdaOHD9_A",
                UserId = "8WQNA6jP9YeIE2XDbj19AMCfLf93",
                CurrentDate = Convert.ToDateTime(currentDate)
            };
            var leaveManager = new LeaveManager();
            var eventList = await leaveManager.GetEvents(leaveRequestModel);
            //var currentDateVal = Convert.ToDateTime(currentDate);
            //var startDate = new DateTime(currentDateVal.Year, currentDateVal.Month, 1);
            //var endDate = startDate.AddMonths(1).AddDays(-1);
            //var utilizeStr = System.IO.File.ReadAllText("json.json");
            //var utilizeObj = System.Text.Json.JsonSerializer.Deserialize<List<LeaveInfo>>(utilizeStr);

            //var leaveDic = new Dictionary<string, List<LeaveInfo>>();
            //var eventApis = new List<EventApi>();
            //foreach (var obj in utilizeObj.Where(a => Convert.ToDateTime(a.start) >= startDate && Convert.ToDateTime(a.end) <= endDate))
            //{
            //    var eventVal = new EventApi
            //    {
            //        source = new EventSourceApi { id = obj.uid },
            //        start = Convert.ToDateTime(obj.start).AddHours(8),
            //        end = Convert.ToDateTime(obj.end).AddHours(16),
            //        startStr = obj.start,
            //        endStr = obj.end,
            //        title = obj.tittle,
            //        allDay = obj.isHalfDay,
            //        id = obj.id.ToString(),
            //        backgroundColor = "#696cff",
            //        url = ""
            //    };
            //    eventApis.Add(eventVal);
            //}

            return eventList.ToList();
        }

        [HttpPost]
        [Route("addevent")]
        public async Task<IActionResult> AddEvent(LeaveInfo eventApi)
        {
            var lm =  new LeaveManager();
            await lm.AddEvent(eventApi);
            return Ok(eventApi);
        }
    }
}
