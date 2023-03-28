namespace PMAssist.Models
{
    public class EventApi
    {
        public string ID { get; set; } = string.Empty;
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool AllDay { get; set; } = false;
        public string Title { get; set; } = string.Empty;
    }
}
