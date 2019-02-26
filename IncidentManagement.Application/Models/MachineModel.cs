using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Application.Models
{
    public class MachineModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public List<IncidentModel> Incidents { get; set; }
    }
}
