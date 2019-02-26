using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Application.Models
{
    public class Password
    {
        public string Hash { get; set; }
        public byte[] Salt { get; set; }
    }
}
