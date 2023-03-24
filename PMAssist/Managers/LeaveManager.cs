using PMAssist.Interfaces;
using PMAssist.Models;
using System.Text;
using System.Text.Json;

namespace PMAssist.Managers
{
    public class LeaveManager
    {
        private static IDataAccessRepository dataAccess;
        private static readonly string URL = @"utilize";
        public LeaveManager(IDataAccessRepository dataAccessRepository)
        {
            dataAccess = dataAccessRepository;
        }

        public LeaveManager()
        {

        }

        static LeaveManager()
        {
            dataAccess = new DataAccessRepository();
        }

        public async Task<IEnumerable<EventApi>> GetEvents(LeaveRequestModel leaveRequestModel)
        {
            var month = leaveRequestModel.CurrentDate.Month;
            var year = leaveRequestModel.CurrentDate.Year;
            var url = $"{URL}/{year}/{month}";

            var utilizeData = await dataAccess.GetAll(leaveRequestModel.AuthToken, url);

            var rawData = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>(utilizeData);

            if (rawData == null)
            {
                return new List<EventApi>();
            }

            var events = new List<EventApi>();

            foreach (var user in rawData)
            {
                foreach (var when in user.Value)
                {
                    if (when.Value.ContainsKey("PTO"))
                    {
                        events.Add(new EventApi
                        {
                            start = new DateTime(year, month, Convert.ToInt32(when.Key)),
                            end = new DateTime(year, month, Convert.ToInt32(when.Key)),
                            title = (await UserManager.GetUser(user.Key)).Name,
                            id = $"{new DateTime(year, month, Convert.ToInt32(when.Key)).ToString("yyyyMMdd")}|{user.Key}",
                            source = new EventSourceApi { url = "", id = user.Key,startStr = new DateTime(year, month, Convert.ToInt32(when.Key)).ToString("yyyy-MM-dd"),endStr = new DateTime(year, month, Convert.ToInt32(when.Key)).ToString("yyyy-MM-dd") },
                            url = "",
                            allDay = when.Value.FirstOrDefault().Value == "4" ? false : true
                        });
                    }
                }
            }

            return events;
        }

        public async Task AddEvent(LeaveInfo eventApi)
        {
            var month = eventApi.Start.Month;
            var year = eventApi.Start.Year;
            var date = eventApi.Start.Day;

            var id = eventApi.UID;
            var url = $"{URL}/{year}/{month}/{id}/{date}.json";


            var value = eventApi.IsHalfDay ? "4" : "8";
            var kvp = $"{{\"PTO\":\"{value}\"}}";
            var data = $"{{\"{id}\":{kvp}}}";

           await dataAccess.PatchData(eventApi.AuthToken, url, kvp);

        }

        public async Task DeleteEvent(LeaveInfo eventApi)
        {
            var month = eventApi.Start.Month;
            var year = eventApi.Start.Year;
            var date = eventApi.Start.Day;

            var id = eventApi.UID;
            var url = $"{URL}/{year}/{month}/{id}/{date}/PTO.json";

            await dataAccess.DeleteData(eventApi.AuthToken, url);
        }
    }
}
