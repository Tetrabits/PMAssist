namespace PMAssist.Models.External
{

    public class ActivityEx
    {
        public ActivityEx() { }
        public ActivityEx(Activity activity) 
        {
            Actual = 0;
            Client = activity.Client;
            CreatedOn = activity.CreatedOn;
            Id = activity.ID;
            LinkID = activity.LinkID;
            Plan = activity.Plan;
            Status = activity.Status;
            TotalSpent = activity.Actuals.Sum(n => n.Value);
            Type = activity.Type;
            ClosedOn = activity.ClosedOn;
            What = activity.What;
        }

        public ActivityEx(Activity activity, string linkId):this(activity)
        {
            LinkID = linkId;            
        }

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
