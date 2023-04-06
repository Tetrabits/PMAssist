namespace PMAssist.Models.External
{
    public class UserEx
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<ActivityEx> YesterdayActivities { get; set; } = new List<ActivityEx>();
        public IEnumerable<ActivityEx> Activities { get; set; } = new List<ActivityEx>();
        public IEnumerable<ActivityEx> FutureActivities { get; set; } = new List<ActivityEx>();
    }
}
