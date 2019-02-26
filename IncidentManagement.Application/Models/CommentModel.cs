
namespace IncidentManagement.Application.Models
{
    public class CommentModel
    {
        public UserModel User { get; set; }
        public int? IncidentId { get; set; }
        public string Text { get; set; }
    }
}
