﻿namespace PMAssist.Helpers
{
    public static class UrlHelper
    {
        public static class Utilize
        {
            private static string baseUrl = "utilize";
            public static string YearUrl(DateTime date)
            {
                return $"{baseUrl}/{date.Year}";
            }

            public static string MonthUrl(DateTime date)
            {
                return $"{YearUrl(date)}/{date.Month.ToString().PadLeft(2, '0')}";

            }
            public static string IdUrl(DateTime date, string userId)
            {
                return $"{MonthUrl(date)}/{userId}";
            }

            public static string DayUrl(DateTime date, string userId)
            {
                return $"{IdUrl(date, userId)}/{date.Day.ToString().PadLeft(2, '0')}";
            }

            public static string PtoUrl(DateTime date, string userId)
            {
                return $"{DayUrl(date, userId)}/PTO";
            }
        }

        public static class Project
        {
            private static string baseUrl = "projects";
            public static string ProjectsUrl()
            {
                return $"{baseUrl}.json";
            }
            public static string ProjectUrl(string projectKey)
            {
                return $"{baseUrl}/{projectKey}.json";
            }

        }

        public static class Sprint
        {
            private static string baseUrl = "sprints";
            public static string SprintUrl(string projectKey)
            {
                return $"{baseUrl}/{projectKey}.json";
            }
            public static string SprintActivityUrl(string sprintKey, string userKey, string activityKey)
            {
                return $"{baseUrl}/{sprintKey}/activities/{userKey}/{activityKey}";
            }
            public static string SprintActivityActualsUrl(string sprintKey, string userKey, string activityKey)
            {
                return $"{baseUrl}/{sprintKey}/activities/{userKey}/{activityKey}/actuals";
            }
            public static string SprintActivityStatusUrl(string sprintKey, string userKey, string activityKey)
            {
                return $"{baseUrl}/{sprintKey}/activities/{userKey}/{activityKey}/status";
            }
            public static string SprintBugUrl(string sprintKey, string bugKey, string userKey, string activityKey)
            {
                return $"{baseUrl}/{sprintKey}/bugs/{bugKey}/{userKey}/{activityKey}";
            }
            public static string SprintBugActualsUrl(string sprintKey, string bugKey, string userKey, string activityKey)
            {
                return $"{baseUrl}/{sprintKey}/bugs/{bugKey}/{userKey}/{activityKey}/actuals";
            }
            public static string SprintBugStatusUrl(string sprintKey, string bugKey, string userKey, string activityKey)
            {
                return $"{baseUrl}/{sprintKey}/bugs/{bugKey}/{userKey}/{activityKey}/status";
            }
            public static string SprintBugRCAUrl(string sprintKey, string bugKey)
            {
                return $"{baseUrl}/{sprintKey}/bugs/{bugKey}/RCA";
            }

            public static string SprintStoryActivityUrl(string sprintKey, string storyKey, string userKey, string activityKey)
            {
                return $"{baseUrl}/{sprintKey}/stories/{storyKey}/{userKey}/{activityKey}";
            }
            public static string SprintStoryActivityActualsUrl(string sprintKey, string storyKey, string userKey, string activityKey)
            {
                return $"{baseUrl}/{sprintKey}/stories/{storyKey}/{userKey}/{activityKey}/actuals";
            }
            public static string SprintStoryActivityStatusUrl(string sprintKey, string storyKey, string userKey, string activityKey)
            {
                return $"{baseUrl}/{sprintKey}/stories/{storyKey}/{userKey}/{activityKey}/status";
            }
        }

        public static class Story
        {
            private static string baseUrl = "stories";
            public static string StoryUrl(string storyKey)
            {
                return $"{baseUrl}/{storyKey}";
            }

            public static string UserUrl(string storyKey, string userKey)
            {
                return $"{baseUrl}/{storyKey}/{userKey}";
            }

            public static string ActivityUrl(string storyKey, string userKey, string activityKey)
            {
                return $"{baseUrl}/{storyKey}/{userKey}/{activityKey}";
            }

            public static string ActivityFieldUrl(string storyKey, string userKey, string activityKey, string activityFiledKey)
            {
                return $"{baseUrl}/{storyKey}/{userKey}/{activityKey}/{activityFiledKey}";
            }
        }
    }
}