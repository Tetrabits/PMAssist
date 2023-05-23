using System.Text.Json.Serialization;

namespace PMAssist.Models
{
    public class Sprint
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = string.Empty;
        [JsonPropertyName("number")]
        public short Number { get; set; } = 0;
        [JsonPropertyName("startsOn")]
        public DateTime StartsOn { get; set; }
        [JsonPropertyName("endsOn")]
        public DateTime EndsOn { get; set; }
        [JsonPropertyName("duration")]
        public short Duration { get; set; } = 14;
        [JsonPropertyName("bugs")]
        public Dictionary<string, Dictionary<string, object>> Bugs { get; set; } = new();
        [JsonPropertyName("activities")]
        public Dictionary<string, Dictionary<string, Activity>> Activities { get; set; } = new();
        [JsonPropertyName("stories")]
        public Dictionary<string, Dictionary<string, Dictionary<string, Activity>>> Stories { get; set; } = new();

    }
}
