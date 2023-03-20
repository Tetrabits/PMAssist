using System;

namespace PMAssist.Models
{
    public class LeaveInfo
    {
        public int id { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string tittle { get; set; }
        public bool isHalfDay { get; set; }
        public string uid { get; set; }
    }
}
