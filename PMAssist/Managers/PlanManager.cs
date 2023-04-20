using PMAssist.Helpers;
using PMAssist.Interfaces;
using PMAssist.Models;
using System.Text.Json;

namespace PMAssist.Managers
{
    public class PlanManager : IPlanManager
    {
        private static IDataAccessRepository dataAccess;
        public PlanManager() { }

        static PlanManager()
        {
            dataAccess = new DataAccessRepository();
        }

        public async Task PlanSprint(ActivityRequestModel activityRequestModel)
        {
            var url = string.Empty;
            var activityId = !string.IsNullOrWhiteSpace(activityRequestModel.Activity.Id) ? activityRequestModel.Activity.Id : Guid.NewGuid().ToString();
            var data = string.Empty;
            switch (activityRequestModel.LinkType)
            {
                case "Activity":
                    url = $"{UrlHelper.Sprint.SprintStoryActivityUrl(activityRequestModel.SprintKey, activityRequestModel.LinkKey, activityRequestModel.UserKey, activityId)}.json";
                    activityRequestModel.Activity.Id = activityId;
                    data = JsonSerializer.Serialize(activityRequestModel.Activity);
                    break;
                case "Story":
                    url = $"{UrlHelper.Sprint.SprintStoryUrl(activityRequestModel.SprintKey, activityRequestModel.UserKey)}.json";
                    data = $"{{\"status\":\"{activityRequestModel.Activity.Status}\",\"storypoint\":\"{activityRequestModel.Activity.Plan}\"}}";
                    break;
                case "Bug":
                    url = $"{UrlHelper.Sprint.SprintBugUrl(activityRequestModel.SprintKey, activityRequestModel.LinkKey)}.json";
                    data = $"{{\"rca\":{activityRequestModel.Activity.What}}}";
                    break;
            }
            if (!string.IsNullOrWhiteSpace(url) && !string.IsNullOrWhiteSpace(data))
            {
                await dataAccess.PatchData(activityRequestModel.AuthToken, url, data);
            }
            else
            {
                throw new Exception("Invalid link type");
            }
        }
    }
}
