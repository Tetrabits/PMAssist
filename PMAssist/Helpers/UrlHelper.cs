namespace PMAssist.Helpers
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
            public static string SprintActivityUrl(string projectKey, string userKey)
            {
                return $"{baseUrl}/{projectKey}/activities/{userKey}";
            }
            public static string SprintBugUrl(string projectKey, string userKey)
            {
                return $"{baseUrl}/{projectKey}/bugs/{userKey}";
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
            public static string SprintActivityUrl(string projectKey, string userKey)
            {
                return $"{baseUrl}/{projectKey}/activities/{userKey}";
            }
            public static string SprintBugUrl(string projectKey, string userKey)
            {
                return $"{baseUrl}/{projectKey}/bugs/{userKey}";
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
            public static string SprintActivityUrl(string projectKey, string userKey)
            {
                return $"{baseUrl}/{projectKey}/activities/{userKey}";
            }
            public static string SprintBugUrl(string projectKey, string userKey)
            {
                return $"{baseUrl}/{projectKey}/bugs/{userKey}";
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
            public static string SprintActivityUrl(string projectKey, string userKey)
            {
                return $"{baseUrl}/{projectKey}/activities/{userKey}";
            }
            public static string SprintBugUrl(string projectKey, string userKey)
            {
                return $"{baseUrl}/{projectKey}/bugs/{userKey}";
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
