using Microsoft.AspNetCore.Mvc;
using PMAssist.Adaptors;
using PMAssist.Helpers;
using PMAssist.Interfaces;
using PMAssist.Models;
using PMAssist.Models.External;
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

        public async Task<ProjectEx> GetSprint(string sprintKey, ProjectEx project)
        {
            var url = UrlHelper.Sprint.SprintUrl(sprintKey);            
            var content = await dataAccess.GetData(url);

            try
            {
                var sprint = JsonSerializer.Deserialize<Sprint>(content)??new Sprint();
                var sprintAdaptor = new SprintAdaptor();
                var projectEx = sprintAdaptor.Adapt(sprint);
                sprint = project.Sprints.FirstOrDefault(n => n.Key == sprintKey)?? new Sprint();
                projectEx.SprintNumber = sprint.Number;
                projectEx.SprintDuration = sprint.Duration;
                projectEx.Duration = project.Duration;
                projectEx.Name = project.Name;
                projectEx.StartsOn = sprint.StartsOn;
                projectEx.EndsOn = sprint.EndsOn;
                return projectEx;
            }
            catch (Exception ex )
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


    }
}
