using Microsoft.AspNetCore.Identity;
using PMAssist.Interfaces;
using PMAssist.Models;
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
                        });
                    }
                }
            }

            return events;
        }
    }
}
