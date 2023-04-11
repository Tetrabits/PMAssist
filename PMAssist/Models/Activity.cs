using System.Text.Json.Serialization;

namespace PMAssist.Models
{

    public class Activity
    {
        [JsonPropertyName("createdOn")]
        public DateTime CreatedOn { get; set; }
        [JsonPropertyName("closedOn")]
        public DateTime ClosedOn { get; set; }
        [JsonPropertyName("id")]
        public string ID { get; set; } = string.Empty;//  Unique ID System Generated
        [JsonPropertyName("linkId")]
        public string LinkID { get; set; } = string.Empty;
        [JsonPropertyName("what")]
        public string What { get; set; } = string.Empty;
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty; //Type: [Design, Development, Testing, Review, Deploy, Documentation, Support]
        [JsonPropertyName("client")]
        public bool Client { get; set; } //boolean Yes means this was work of Client
        [JsonPropertyName("plan")]
        public double Plan { get; set; }//: number
        [JsonPropertyName("actual")]
        public int Actual { get; set; }//: Sum of Actuls
        [JsonPropertyName("actuals")]
        public List<Effort> Actuals { get; set; } = new List<Effort>(); //: [Date, number] Actual recorded each day
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;//: [Planned, In Progress, Closed]
    }
}
