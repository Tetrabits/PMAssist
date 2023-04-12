using System.Text.Json.Serialization;

namespace PMAssist.Models
{
    public class ActivityRequestModel
    {
        [JsonPropertyName("authToken")] public string AuthToken { get; set; } = string.Empty;
        [JsonPropertyName("sprintKey")] public string SprintKey { get; set; } = string.Empty;
        [JsonPropertyName("linkType")] public string LinkType { get; set; } = string.Empty;
        [JsonPropertyName("linkKey")] public string LinkKey { get; set; } = string.Empty;
        [JsonPropertyName("userKey")] public string UserKey { get; set; } = string.Empty;
        [JsonPropertyName("activity")] public ActivityAttributes Activity { get; set; } = new ActivityAttributes();
        [JsonPropertyName("spentOn")] public DateTime SpentOn { get; set; }
        [JsonPropertyName("howMuch")] public string HowMuch { get; set; } = string.Empty;
    }
}
