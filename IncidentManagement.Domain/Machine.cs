using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentManagement.Domain
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
