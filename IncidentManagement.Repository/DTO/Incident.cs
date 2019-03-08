using System;
using System.Collections.Generic;

namespace IncidentManagement.Repository.DTO
{
    public class Incident
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public Machine Machine { get; set; }
        public User CreatedBy { get; set; }
        public User AssignedTo { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
