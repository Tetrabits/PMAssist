namespace PMAssist.Models.External
{

    public class ActivityEx
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ClosedOn { get; set; }
        public string Id { get; set; } = string.Empty;
        public string LinkID { get; set; } = string.Empty;
        public string What { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool Client { get; set; }
        public double Plan { get; set; }
        public double TotalSpent { get; set; }
        public double Actual { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
