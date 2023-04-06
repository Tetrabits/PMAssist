namespace PMAssist.Models.External
{
    public class Project
    {
        public string Name { get; set; } = string.Empty;
        public short SprintDuration { get; set; }
        public short SprintNumber { get; set; }
        public DateTime StartsOn { get; set; }
        public DateTime EndsOn { get; set; }
        public short Duration { get; set; }
        public IEnumerable<StoryEx> Stories { get; set; } = new List<StoryEx>();
        public IEnumerable<BugEx> Bugs { get; set; } = new List<BugEx>();
        public IEnumerable<UserEx> Users { get; set; } = new List<UserEx>();
    }
}
