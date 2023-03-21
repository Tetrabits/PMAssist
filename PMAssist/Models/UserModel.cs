namespace PMAssist.Models
{
    public class UserModel
    {
        public string Name { get; set; } = string.Empty;
        public bool Status { get; set; }=false;
        public string UID { get; internal set; }
    }
}