namespace PMAssist.Models
{
    public class Bug
    {
        Dictionary<string, Dictionary<string, object>> UserActivity { get; set; } = new();
    }
}
