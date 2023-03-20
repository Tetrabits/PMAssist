namespace PMAssist.Models
{
    public class LeaveInfo
    {
        public string UID { get; set; } = string.Empty;
        public DateTime Start { get; set; } = DateTime.Today;
        public DateTime End { get; set; } = DateTime.Today;
        public bool IsHalfDay { get; set; } = false;
        public string AuthToken { get; set; } = string.Empty;
    }
}
