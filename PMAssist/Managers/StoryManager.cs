using PMAssist.Helpers;
using PMAssist.Interfaces;
using PMAssist.Models;
using System.Diagnostics;
using System.Text.Json;

namespace PMAssist.Managers
{
    public class StoryManager
    {
        private static IDataAccessRepository dataAccess;
        public StoryManager() { }

        static StoryManager()
        {
            dataAccess = new DataAccessRepository();
        }

        public async Task AddActivity(ActivityRequestModel activityRequestModel)
        {
            var url = string.Empty;
            var activityId = !string.IsNullOrWhiteSpace(activityRequestModel.Activity.Id) ? activityRequestModel.Activity.Id : Guid.NewGuid().ToString();
            switch (activityRequestModel.LinkType)
            {
                case "Sprint":
                    url = $"{UrlHelper.Sprint.SprintActivityUrl(activityRequestModel.SprintKey, activityRequestModel.UserKey, activityId)}.json";
                    break;
                case "Story":
                    url = $"{UrlHelper.Sprint.SprintStoryActivityUrl(activityRequestModel.SprintKey, activityRequestModel.LinkKey, activityRequestModel.UserKey, activityId)}.json";
                    break;
                case "Bug":
                    url = $"{UrlHelper.Sprint.SprintBugActivityUrl(activityRequestModel.SprintKey, activityRequestModel.LinkKey, activityRequestModel.UserKey, activityId)}.json";
                    break;
            }
            if (!string.IsNullOrWhiteSpace(url))
            {
                activityRequestModel.Activity.Id = activityId;
                if (activityRequestModel.SpentOn != DateTime.MinValue && activityRequestModel.HowMuch != int.MaxValue)
                {
                    activityRequestModel.Activity.Actuals.Add(activityRequestModel.SpentOn.ToString("yyyyMMdd"), activityRequestModel.HowMuch);
                }
                var activityContent = JsonSerializer.Serialize(activityRequestModel.Activity);
                await dataAccess.PatchData(activityRequestModel.AuthToken, url, activityContent);
            }
            else
            {
                throw new Exception("Invalid link type");
            }
        }

        public async Task UpdateActivity(ActivityRequestModel activityRequestModel)
        {
            var url = string.Empty;
            var updateUrl = string.Empty;
            var activityId = !string.IsNullOrWhiteSpace(activityRequestModel.Activity.Id) 
                                ? activityRequestModel.Activity.Id : throw new Exception("Activity ID not provided");
            switch (activityRequestModel.LinkType)
            {
                case "Sprint":
                    url = $"{UrlHelper.Sprint.SprintActivityStatusUrl(activityRequestModel.SprintKey, activityRequestModel.UserKey, activityId)}.json";
                    if (activityRequestModel.SpentOn != DateTime.MinValue && activityRequestModel.HowMuch != int.MaxValue)
                    {
                        updateUrl = $"{UrlHelper.Sprint.SprintActivityActualsUrl(activityRequestModel.SprintKey, activityRequestModel.UserKey, activityId)}.json";
                    }
                    break;
                case "Story":
                    url = $"{UrlHelper.Sprint.SprintStoryActivityStatusUrl(activityRequestModel.SprintKey, activityRequestModel.LinkKey, activityRequestModel.UserKey, activityId)}.json";
                    if (activityRequestModel.SpentOn != DateTime.MinValue && activityRequestModel.HowMuch != int.MaxValue)
                    {
                        updateUrl = $"{UrlHelper.Sprint.SprintStoryActivityActualsUrl(activityRequestModel.SprintKey, activityRequestModel.LinkKey, activityRequestModel.UserKey, activityId)}.json";
                    }
                    break;
                case "Bug":
                    url = $"{UrlHelper.Sprint.SprintBugStatusUrl(activityRequestModel.SprintKey, activityRequestModel.LinkKey, activityRequestModel.UserKey, activityId)}.json";
                    if (activityRequestModel.SpentOn != DateTime.MinValue && activityRequestModel.HowMuch != int.MaxValue)
                    {
                        updateUrl = $"{UrlHelper.Sprint.SprintBugActualsUrl(activityRequestModel.SprintKey, activityRequestModel.LinkKey, activityRequestModel.UserKey, activityId)}.json";
                    }
                    break;
            }
            if (!string.IsNullOrWhiteSpace(url))
            {
                await dataAccess.PatchData(activityRequestModel.AuthToken, url, activityRequestModel.Activity.Status);
            }
            else
            {
                throw new Exception("Invalid link type");
            }

            if (!string.IsNullOrWhiteSpace(updateUrl))
            {
                var actualsJson = $"{{\"{activityRequestModel.SpentOn.ToString("yyyyMMdd")}\":\"{activityRequestModel.HowMuch}\"}}";
                await dataAccess.PatchData(activityRequestModel.AuthToken, updateUrl, actualsJson);
            }
        }
    }
}
