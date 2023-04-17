using System.Text.Json.Serialization;

namespace PMAssist.Models.External
{
    public class ProjectEx
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("projectKey")]
        public string ProjectKey { get; set; } = string.Empty;
        [JsonPropertyName("sprintDuration")]
        public short SprintDuration { get; set; }
        [JsonPropertyName("sprints")]
        public IList<Sprint> Sprints { get; set; } = new List<Sprint>();
        /// <summary>
        /// This is obsolet
        /// </summary>
        [JsonPropertyName("sprintNumber")]
        public short SprintNumber { get; set; }
        [JsonPropertyName("startsOn")]
        public DateTime StartsOn { get; set; }
        [JsonPropertyName("endsOn")]
        public DateTime EndsOn { get; set; }
        [JsonPropertyName("duration")]
        public short Duration { get; set; }
        [JsonPropertyName("stories")]
        public IEnumerable<StoryEx> Stories { get; set; } = new List<StoryEx>();
        [JsonPropertyName("bugs")]
        public IEnumerable<BugEx> Bugs { get; set; } = new List<BugEx>();
        [JsonPropertyName("users")]
        public IList<UserEx> Users { get; set; } = new List<UserEx>();
    }
}
