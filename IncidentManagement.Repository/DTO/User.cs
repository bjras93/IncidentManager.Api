using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IncidentManagement.Repository.DTO
{
    public class User
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }        
        public byte[] Salt { get; set; }
        public UserType UserType { get; set; }
    }
}
