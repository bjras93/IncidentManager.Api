namespace IncidentManagement.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Incident Incident { get; set; }
        public Project Project { get; set; }
        public User User { get; set; }
    }
}
