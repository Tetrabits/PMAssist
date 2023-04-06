namespace PMAssist.Models
{
    public class Sprint
    {
        public int SprintNumber { get; set; } = 0;
        public DateTime StartsOn { get; set; }
        public DateTime EndsOn { get; set; }
        public short Duration { get; set; } = 14;

        public IEnumerable<Story> Stories { get; set; }
        public IEnumerable<Bug> Bugs { get; set; }
        public IEnumerable<User> Users { get; set; }

    }
}
