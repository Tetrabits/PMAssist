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
                return $"{YearUrl(date)}/{date.Month.ToString().PadLeft(2,'0')}";
                
            }
            public static string IdUrl(DateTime date,string userId)
            {
                return $"{MonthUrl(date)}/{userId}";
            }

            public static string DayUrl(DateTime date,string userId)
            {
                return $"{IdUrl(date,userId)}/{date.Day.ToString().PadLeft(2, '0')}";
            }

            public static string PtoUrl(DateTime date,string userId)
            {
                return $"{DayUrl(date,userId)}/PTO";
            }
        }
    }
}
