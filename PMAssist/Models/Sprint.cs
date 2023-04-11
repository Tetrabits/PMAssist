using System.Text.Json.Serialization;

namespace PMAssist.Models
{
    public class Sprint
    {
        [JsonPropertyName("sprintnumber")]        
        public int SprintNumber { get; set; } = 0;
        [JsonPropertyName("startson")]
        public DateTime StartsOn { get; set; }
        [JsonPropertyName("endson")]
        public DateTime EndsOn { get; set; }
        [JsonPropertyName("duration")]
        public short Duration { get; set; } = 14;

        //[JsonPropertyName("stories")]
        //public IEnumerable<Story> Stories { get; set; }
        [JsonPropertyName("bugs")]
        public IEnumerable<Bug> Bugs { get; set; }
        [JsonPropertyName("users")]
        public IEnumerable<User> Users { get; set; }
        [JsonPropertyName("stories")]
        public Dictionary<string, Dictionary<string, List<Activity>>> Stories { get; set; }

    }
}
