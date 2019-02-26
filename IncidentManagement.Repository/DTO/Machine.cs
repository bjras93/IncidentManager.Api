using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Repository.DTO
{
    [Table("Machine")]
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Incident> Incidents{ get; set; }
        public Location Location { get; set; }
    }
}
