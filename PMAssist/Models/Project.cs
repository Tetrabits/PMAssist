using System.Text.Json.Serialization;

namespace PMAssist.Models
{
    public class Project
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("sprintDuration")]
        public short SprintDuration { get; set; } = 14;
        [JsonPropertyName("sprints")]
        public Dictionary<string, Sprint> Sprints { get; set; } = new Dictionary<string, Sprint>();
    }
}
