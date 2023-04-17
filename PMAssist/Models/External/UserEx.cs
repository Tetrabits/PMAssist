namespace PMAssist.Models.External
{
    public class UserEx
    {
        public string Name { get; set; } = string.Empty;
        public string UserKey { get; set; } = string.Empty;
        public List<ActivityEx> YesterdayActivities { get; set; } = new List<ActivityEx>();
        public List<ActivityEx> Activities { get; set; } = new List<ActivityEx>();
        public List<ActivityEx> FutureActivities { get; set; } = new List<ActivityEx>();
    }
}
