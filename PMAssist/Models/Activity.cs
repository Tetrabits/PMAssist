namespace PMAssist.Models
{

    public class Activity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ClosedOn { get; set; }
        public string ID { get; set; } = string.Empty;//  Unique ID System Generated
        public string LinkID { get; set; } = string.Empty;
        public string What { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; //Type: [Design, Development, Testing, Review, Deploy, Documentation, Support]
        public bool Client { get; set; } //boolean Yes means this was work of Client
        public double Plan { get; set; }//: number
        public int Actual { get; set; }//: Sum of Actuls
        public Dictionary<DateTime, int> Actuals { get; set; } = new Dictionary<DateTime, int>(); //: [Date, number] Actual recorded each day
        public string Status { get; set; } = string.Empty;//: [Planned, In Progress, Closed]
    }
}
