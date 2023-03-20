namespace PMAssist.Models
{
    public class EventApi
    {
        public EventSourceApi? source { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public string? startStr { get; set; }
        public string? endStr { get; set; }
        public string? id { get; set; }
        public string? groupId { get; set; }
        public bool? allDay { get; set; }
        public string? title { get; set; }
        public string? url { get; set; }
        public string? display { get; set; }
        public bool? startEditable { get; set; }
        public bool? durationEditable { get; set; }
        public object? constraint { get; set; }
        public bool? overlap { get; set; }
        public object? allow { get; set; }
        public string? backgroundColor { get; set; }
        public string? borderColor { get; set; }
        public string? textColor { get; set; }
        public string[]? classNames { get; set; }
        public Dictionary<string, string>? extendedProps { get; set; }
    }
}
