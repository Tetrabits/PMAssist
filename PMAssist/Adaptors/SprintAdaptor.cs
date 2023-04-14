﻿using PMAssist.Interfaces;
using PMAssist.Models;
using PMAssist.Models.External;

namespace PMAssist.Adaptors
{
    public class SprintAdaptor : IAdaptor<Sprint, ProjectEx>
    {
        public ProjectEx Adapt(Sprint source)
        {
            var projectEx = new ProjectEx();

            foreach(var story in source.Stories) 
            {
                var storyKey = story.Key;
                foreach (var user in story.Value)
                {
                    var userKey = user.Key;
                    var existingUser = projectEx.Users.FirstOrDefault(n=>n.Name == userKey);

                    if (existingUser == null) 
                    {
                        existingUser = new UserEx { Name=userKey};
                        projectEx.Users.Add(existingUser);
                    }

                    foreach (var activity in user.Value)
                    {
                        var activityKey = activity.Key;                        
                        var newActivityEx = new ActivityEx(activity.Value, storyKey);
                        existingUser.Activities.Add(newActivityEx);
                        
                    }

                }
            }


            foreach (var user in source.Activities)
            {
                var userKey = user.Key;

                foreach (var activity in user.Value)
                {
                    var activityKey = activity.Key;
                    var newActivityEx = new ActivityEx(activity.Value);

                    var existingUser = projectEx.Users.FirstOrDefault(n => n.Name == userKey);
                    
                    if (existingUser == null)
                    {
                        existingUser = new UserEx
                        {
                            Name = userKey
                        };                      

                        //Add users
                        projectEx.Users.Add(existingUser);
                    }

                    existingUser.Activities.Add(newActivityEx);
                }
            }

            return projectEx;
        }
    }
}
