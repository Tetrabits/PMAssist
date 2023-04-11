using System.Text.Json.Serialization;

namespace PMAssist.Models
{
    public class Project
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("sprintduration")]
        public short SprintDuration { get; set; } = 14;
        [JsonPropertyName("sprints")]
        public IEnumerable<Sprint> Sprints { get; set; } = new List<Sprint>();
    }
}
