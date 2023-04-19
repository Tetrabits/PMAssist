using PMAssist.Interfaces;
using PMAssist.Managers;
using PMAssist.Models;
using PMAssist.Models.External;
using System.Linq;

namespace PMAssist.Adaptors
{
    public class SprintAdaptor : IAdaptor<Sprint, ProjectEx>
    {
        protected UserManager UserManager { get; set; }

        public SprintAdaptor()
        {
            UserManager = new UserManager();
        }

        public ProjectEx Adapt(Sprint source)
        {
            var projectEx = new ProjectEx();

            foreach (var story in source.Stories)
            {
                var storyKey = story.Key;
                foreach (var user in story.Value.Users)
                {
                    var status = story.Value.Status;
                    var storyPoint = story.Value.StoryPoint;
                    var storyId = story.Value.ID;
                    var userKey = user.Key;
                    var existingUser = GetUser(projectEx, userKey);
                    existingUser.Activities.AddRange(from activity in user.Value
                                                     let newActivityEx = new ActivityEx(activity.Key, activity.Value, storyKey)
                                                     select newActivityEx);
                }
            }

            foreach (var user in source.Activities)
            {
                var userKey = user.Key;
                var existingUser = GetUser(projectEx, userKey);
                existingUser.Activities.AddRange(from activity in user.Value                                                 
                                                 let newActivityEx = new ActivityEx(activity.Key, activity.Value)
                                                 select newActivityEx);
            }

            return projectEx;
        }

        private UserEx GetUser(ProjectEx projectEx, string userKey)
        {
            var existingUser = projectEx.Users.FirstOrDefault(n => n.UserKey == userKey);

            if (existingUser == null)
            {

                existingUser = new UserEx
                {
                    UserKey = userKey,
                    Name = UserManager.GetUser(userKey).GetAwaiter().GetResult().Name,
                };

                projectEx.Users.Add(existingUser);
            }

            return existingUser;
        }
    }
}
