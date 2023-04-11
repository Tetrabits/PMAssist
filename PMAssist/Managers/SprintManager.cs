using PMAssist.Helpers;
using PMAssist.Interfaces;
using PMAssist.Models;
using System.Text.Json;

namespace PMAssist.Managers
{
    public class SprintManager
    {
        private static IDataAccessRepository dataAccess;
        public SprintManager(IDataAccessRepository dataAccessRepository)
        {
            dataAccess = dataAccessRepository;
        }

        public SprintManager()
        {

        }

        static SprintManager()
        {
            dataAccess = new DataAccessRepository();
        }

        public async Task<IEnumerable<EventApi>> GetLeaves(LeaveRequestModel leaveRequestModel)
        {
            return await Task.Run(() =>
            {
                var previous = new List<EventApi>();
                var current = new List<EventApi>();
                var next = new List<EventApi>();

                var month = leaveRequestModel.Date.Month;
                var year = leaveRequestModel.Date.Year;

                var date = new DateTime(year, month, 1).AddMonths(1);

                Parallel.Invoke(
                    () =>
                    {
                        previous = GetMonthEvents(new LeaveRequestModel
                        {
                            AuthToken = leaveRequestModel.AuthToken,
                            UserId = leaveRequestModel.UserId,
                            Date = leaveRequestModel.Date.AddMonths(-1)
                        }).GetAwaiter().GetResult().ToList();
                    },
                    () =>
                    {
                        current = GetMonthEvents(leaveRequestModel).GetAwaiter().GetResult().ToList();
                    },
                    () =>
                    {
                        next = GetMonthEvents(new LeaveRequestModel
                        {
                            AuthToken = leaveRequestModel.AuthToken,
                            UserId = leaveRequestModel.UserId,
                            Date = leaveRequestModel.Date.AddMonths(1)
                        }).GetAwaiter().GetResult().ToList();

                    });

                previous.AddRange(current);
                previous.AddRange(next);

                return previous;
                var final = new List<EventApi>();
                var title = string.Empty;
                var currentDate = DateTime.Today;
                EventApi? leave = null;

                foreach (var item in previous.OrderBy(n => n.Title).ThenBy(n => n.Start))
                {
                    if (item.Title.Equals(title))
                    {
                        //This is the same person
                        var date1 = (item.Start ?? DateTime.MinValue).Date;
                        if (date1 == currentDate.AddDays(1))
                        {
                            if (leave != null)
                            {
                                leave.End = new DateTime(date1.Year, date1.Month, date1.Day, 23, 59, 59);
                            }
                            currentDate = date1;
                        }
                        else
                        {
                            if (leave != null)
                            {
                                leave.End = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 23, 59, 59);
                                final.Add(leave);
                            }

                            leave = new EventApi
                            {
                                ID = item.ID,
                                Title = item.Title,
                                Start = item.Start,
                                End = item.End
                            };

                            title = item.Title;
                            currentDate = item.Start ?? DateTime.MinValue;
                        }
                    }
                    else
                    {
                        //Person has changed, Add the leave info and then create a Leave Object
                        if (leave != null)
                        {
                            leave.End = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 23, 59, 59);
                            final.Add(leave);
                        }

                        leave = new EventApi
                        {
                            ID = item.ID,
                            Title = item.Title,
                            Start = item.Start,
                            End = item.End
                        };

                        title = item.Title;
                        currentDate = item.Start ?? DateTime.MinValue;
                    }
                }

                return final;
            });

        }

        public async Task<string> GetSprintData(string projectKey, string authToken)
        {
            var url = $"{UrlHelper.Sprint.SprintUrl(projectKey)}";
            var sprinrData = await dataAccess.GetAll(authToken, url);

            try
            {
                var rawData = JsonSerializer.Deserialize<Sprint>(sprinrData);
            }
            catch (Exception ex)
            {

            }
            return sprinrData;
        }


        private async Task<IEnumerable<EventApi>> GetMonthEvents(LeaveRequestModel leaveRequestModel)
        {
            var month = leaveRequestModel.Date.Month;
            var year = leaveRequestModel.Date.Year;
            var url = $"{UrlHelper.Utilize.MonthUrl(leaveRequestModel.Date)}";

            var utilizeData = await dataAccess.GetAll(leaveRequestModel.AuthToken, url);

            if (string.IsNullOrWhiteSpace(utilizeData))
            {
                return new List<EventApi>();
            }

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
                            Start = new DateTime(year, month, Convert.ToInt32(when.Key)),
                            End = new DateTime(year, month, Convert.ToInt32(when.Key)),
                            Title = (await UserManager.GetUser(user.Key)).Name,
                            ID = $"{new DateTime(year, month, Convert.ToInt32(when.Key)).ToString("yyyyMMdd")}|{user.Key}",
                            //source = new EventSourceApi { url = "", id = user.Key,startStr = new DateTime(year, month, Convert.ToInt32(when.Key)).ToString("yyyy-MM-dd"),endStr = new DateTime(year, month, Convert.ToInt32(when.Key)).ToString("yyyy-MM-dd") },
                            //url = "",
                            //AllDay = when.Value.FirstOrDefault().Value == "4" ? false : true
                        });
                    }
                }
            }

            return events;
        }

        public async Task AddEvent(LeaveInfo eventApi)
        {
            var id = eventApi.UID;
            var url = $"{UrlHelper.Utilize.DayUrl(eventApi.Start, id)}.json";


            var value = eventApi.IsHalfDay ? "4" : "8";
            var kvp = $"{{\"PTO\":\"{value}\"}}";
            var data = $"{{\"{id}\":{kvp}}}";

            await dataAccess.PatchData(eventApi.AuthToken, url, kvp);

        }

        public async Task DeleteEvent(LeaveInfo eventApi)
        {
            var id = eventApi.UID;
            var url = $"{UrlHelper.Utilize.PtoUrl(eventApi.Start, id)}.json";

            await dataAccess.DeleteData(eventApi.AuthToken, url);
        }
    }
}
