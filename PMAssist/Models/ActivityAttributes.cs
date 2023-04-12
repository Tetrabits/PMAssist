using System.Text.Json.Serialization;

namespace PMAssist.Models
{
    public class ActivityAttributes
    {
        [JsonPropertyName("client")] public bool Client { get; set; }
        [JsonPropertyName("closedOn")] public DateTime ClosedOn { get; set; }
        [JsonPropertyName("createdOn")] public DateTime CreatedOn { get; set; }
        [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
        [JsonPropertyName("plan")] public string Plan { get; set; } = string.Empty;
        [JsonPropertyName("status")] public string Status { get; set; } = string.Empty;
        [JsonPropertyName("type")] public string Type { get; set; } = string.Empty;
        [JsonPropertyName("what")] public string What { get; set; } = string.Empty;
    }
}
