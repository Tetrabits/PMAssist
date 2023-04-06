namespace PMAssist.Models
{
    public class Project
    {
        public string Name { get; set; } = string.Empty;
        public short SprintDuration { get; set; } = 14;
        public IEnumerable<Sprint> Sprints { get; set; } = new List<Sprint>();
    }
}
