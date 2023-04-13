using Microsoft.AspNetCore.Mvc;
using PMAssist.Helpers;
using PMAssist.Interfaces;
using PMAssist.Models;
using PMAssist.Models.External;
using System.Security.Cryptography.Xml;
using System.Text.Json;

namespace PMAssist.Managers
{
    public class ProjectManager
    {
        private static IDataAccessRepository dataAccess;
        public ProjectManager(IDataAccessRepository dataAccessRepository)
        {
            dataAccess = dataAccessRepository;
        }

        public ProjectManager()
        {

        }

        static ProjectManager()
        {
            dataAccess = new DataAccessRepository();
        }

        public async Task<string> GetSprintKey(string projectKey, DateTime date)
        {
            return await Task.Run(async () =>
            {
                var url = UrlHelper.Project.ProjectUrl(projectKey);

                var response = await dataAccess.GetData(url);

                var project = JsonSerializer.Deserialize<Project>(response);

                if (project is null)
                {
                    return string.Empty;
                }

                //var sprint = project.Sprints.FirstOrDefault(n => n.StartsOn <= date && date <= n.EndsOn);

                //if (sprint != null)
                //{
                //    return $"{projectKey}{sprint.StartsOn:yyyyMMdd}";
                //}

                return string.Empty;
            });

        }

        public async Task<string> PutSprint(string projectKey, Sprint sprint)
        {
            return await Task.Run(async () =>
            {
                var url = UrlHelper.Project.ProjectUrl(projectKey);

                var response = await dataAccess.GetData(string.Empty, url, string.Empty);

                var project = JsonSerializer.Deserialize<Project>(response);
                //var sprintIndex = project.Sprints.Count();


                //url = $"{url}/sprints/{sprintIndex}.json";

                //var x = await dataAccess.PutData(string.Empty, url, JsonSerializer.Serialize(sprint));

                //if (sprint != null)
                //{
                //    return $"{projectKey}{sprint.StartsOn.ToString("yyyyMMdd")}";
                //}
                return string.Empty;
            });

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

        public async Task<IEnumerable<ProjectEx>> GetProjects()
        {
            return await Task.Run(async () =>
            {
                var url = UrlHelper.Project.ProjectsUrl();

                var response = await dataAccess.GetData(url);

                var projects = JsonSerializer.Deserialize<Dictionary<string, Project>>(response);
                var projectsEx = new List<ProjectEx>();

                if (projects == null)
                {
                    return projectsEx;
                }

                foreach (var project in projects)
                {
                    var projectEx = new ProjectEx
                    {
                        ProjectKey = project.Key,
                        Name = project.Value.Name
                    };

                    foreach (var sprint in project.Value.Sprints)
                    {
                        sprint.Value.Key = sprint.Key;
                        projectEx.Sprints.Add(sprint.Value);
                    }
                    projectsEx.Add(projectEx);
                }


                return projectsEx;




            });
        }

        internal Task GetSprintKey(string projectKey, short sprintNumber)
        {
            throw new NotImplementedException();
        }
    }
}
