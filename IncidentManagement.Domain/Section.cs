using System.Collections.Generic;

namespace IncidentManagement.Domain
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Field> Fields { get; set; }
    }
}
