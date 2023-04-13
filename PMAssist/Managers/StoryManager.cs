using PMAssist.Helpers;
using PMAssist.Interfaces;
using PMAssist.Models;
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
                    url = $"{UrlHelper.Sprint.SprintBugUrl(activityRequestModel.SprintKey, activityRequestModel.LinkKey, activityRequestModel.UserKey, activityId)}.json";
                    break;
            }
            if (!string.IsNullOrWhiteSpace(url))
            {
                activityRequestModel.Activity.Id = activityId;
                activityRequestModel.Activity.Actuals.Add(activityRequestModel.SpentOn.ToString("yyyyMMdd"), activityRequestModel.HowMuch);
                var activityContent = JsonSerializer.Serialize(activityRequestModel.Activity);
                await dataAccess.PatchData(activityRequestModel.AuthToken, url, activityContent);
            }
            else
            {
                throw new Exception("Invalid link type");
            }
        }

        //public async Task UpdateActivity(ActivityRequestModel activityRequestModel)
        //{
        //    var url = string.Empty;
        //    switch (activityRequestModel.LinkType)
        //    {
        //        case "Sprint":
        //            url = $"{UrlHelper.Sprint.SprintActivityUrl(activityRequestModel.SprintKey, activityRequestModel.UserKey)}.json";
        //            break;
        //        case "Story":
        //            url = $"{UrlHelper.Sprint.SprintUrl(activityRequestModel.SprintKey)}{UrlHelper.Story.UserUrl(activityRequestModel.LinkKey, activityRequestModel.UserKey)}.json";
        //            break;
        //        case "Bug":
        //            url = $"{UrlHelper.Sprint.SprintBugUrl(activityRequestModel.SprintKey, activityRequestModel.UserKey)}.json";
        //            break;
        //    }
        //    if (!string.IsNullOrWhiteSpace(url))
        //    {
        //        var activityContent = JsonSerializer.Serialize(activityRequestModel);
        //        await dataAccess.PatchData(activityRequestModel.AuthToken, url, activityContent);
        //    }
        //    else
        //    {
        //        throw new Exception("Invalid link type");
        //    }
        //}


    }
}
