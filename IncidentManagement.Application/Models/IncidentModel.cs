using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Application.Models
{
    public class IncidentModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public MachineModel Machine { get; set; }
        public UserModel CreatedBy { get; set; }
        public UserModel AssignedTo { get; set; }
        public List<CommentModel> Comments{ get; set; }
    }
}
