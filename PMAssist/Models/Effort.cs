using System.Text.Json.Serialization;

namespace PMAssist.Models
{
    public class Effort
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("howmuch")]
        public int HowMuch { get; set; }
    }
}
