namespace PMAssist.Models
{
    public class LeaveRequestModel
    {
        public DateTime Date { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string AuthToken { get; set; } = string.Empty;
    }
}