
namespace IncidentManagement.Application.Models
{
    public class CommentModel
    {
        int Id { get; set; }
        public UserModel User { get; set; }
        public IncidentModel Incident { get; set; }
        public string Text { get; set; }
    }
}
