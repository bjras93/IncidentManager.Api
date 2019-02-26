
namespace IncidentManagement.Application.Models
{
    public class CommentModel
    {
        public int? UserId { get; set; }
        public int? IncidentId { get; set; }
        public string Text { get; set; }
    }
}
