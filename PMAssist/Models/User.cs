namespace PMAssist.Models
{
    public class User
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Activity> Activities { get; set; }

    }
}
