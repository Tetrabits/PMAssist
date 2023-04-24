namespace PMAssist.Models
{
    public class Story
    {
        public string ID { get; set; } = string.Empty;
        public short Points { get; set; }
        public string Status { get; set; } = string.Empty;
        public short StoryPoint { get; set; } = 0;
        public Dictionary<string, Dictionary<string, Activity>> Users { get; set; } = new Dictionary<string, Dictionary<string, Activity>>();
        public DateTime Created { get; set; }
    }
}
