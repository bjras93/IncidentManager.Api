using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Repository.DTO
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Incident Incident { get; set; }
        public User User { get; set; }
    }
}
