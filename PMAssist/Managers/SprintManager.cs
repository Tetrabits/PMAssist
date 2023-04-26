using PMAssist.Adaptors;
using PMAssist.Helpers;
using PMAssist.Interfaces;
using PMAssist.Models;
using PMAssist.Models.External;
using System.Text.Json;

namespace PMAssist.Managers
{
    public class SprintManager : ISprintManager
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

        public async Task<ProjectEx> GetSprint(string sprintKey, ProjectEx project)
        {
            var url = UrlHelper.Sprint.SprintUrl(sprintKey);
            var content = await dataAccess.GetData(url);

            try
            {
                var sprint = JsonSerializer.Deserialize<Sprint>(content) ?? new Sprint();
                var sprintAdaptor = new SprintAdaptor();
                var projectEx = sprintAdaptor.Adapt(sprint);
                sprint = project.Sprints.FirstOrDefault(n => n.Key == sprintKey) ?? new Sprint();
                projectEx.SprintNumber = sprint.Number;
                projectEx.SprintDuration = sprint.Duration;
                projectEx.Duration = project.Duration;
                projectEx.Name = project.Name;
                projectEx.StartsOn = sprint.StartsOn;
                projectEx.EndsOn = sprint.EndsOn;
                return projectEx;
            }
            catch (Exception ex)
            {

                throw;
            }




            //foreach (var storyKey in sprint.Stories)
            //{
            //    foreach (var userKey in storyKey.Value)
            //    {

            //        var activities = userKey.Value.Where(n => n.Status != "Completed")
            //            .Select(n => new ActivityEx
            //            {
            //                ClosedOn = n.ClosedOn,
            //                CreatedOn = n.CreatedOn,
            //                Client = n.Client,
            //                Id = n.ID,
            //                LinkID = storyKey.Key,
            //                Plan = n.Plan,
            //                Status = n.Status,
            //                //TotalSpent = n.Actuals.Sum(n => n.Value),
            //                Type = n.Type,
            //                What = n.What
            //            }).ToList();

            //        var user = projectEx.Users.FirstOrDefault(n => n.Name == userKey.Key);
            //        if (user == null)
            //        {

            //            projectEx.Users.Add(new UserEx
            //            {
            //                Name = userKey.Key,
            //                Activities = activities
            //                //YesterdayActivities = activities.Where(n => n.CreatedOn.Date < today.Date),
            //                //Activities = activities.Where(n => n.CreatedOn.Date == today.Date),
            //                //FutureActivities = activities.Where(n => n.CreatedOn.Date > today.Date),
            //            });
            //        }
            //        else
            //        {
            //            user.Activities.AddRange(activities);
            //        }
            //    }

            //}



        }

        public async Task<IEnumerable<Story>> GetStories(string sprintKey)
        {
            var url = UrlHelper.Sprint.SprintUrl(sprintKey);
            var content = await dataAccess.GetData(url);
            var sprint = JsonSerializer.Deserialize<Sprint>(content);

            var stories = new List<Story>();
            foreach (var story in sprint?.Stories??new Dictionary<string, Story>())
            { 
                var storyKey = story.Key;
                story.Value.ID = storyKey;
                story.Value.Users.Clear();
                stories.Add(story.Value);
            }

            return stories;
        }

        public async Task AddSprintActivity(ActivityRequestModel activityRequestModel)
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
                    url = $"{UrlHelper.Sprint.SprintStoryUrl(activityRequestModel.SprintKey, activityRequestModel.Activity.What)}.json";
                    data = $"{{\"status\":\"{activityRequestModel.Activity.Status}\",\"storypoint\":\"{activityRequestModel.Activity.Plan}\"}}";
                    break;
                case "Bug":
                    url = $"{UrlHelper.Sprint.SprintBugUrl(activityRequestModel.SprintKey, activityRequestModel.Activity.What)}.json";
                    data = $"{{\"story\":{activityRequestModel.LinkKey}}}";
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
