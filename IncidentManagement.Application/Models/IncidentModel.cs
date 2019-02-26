using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Application.Models
{
    public class IncidentModel
    {
        public int? Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public int? LocationId { get; set; }
        public int? CreatedBy { get; set; }
        public int? AssignedTo { get; set; }
        public List<CommentModel> Comments{ get; set; }
    }
}
