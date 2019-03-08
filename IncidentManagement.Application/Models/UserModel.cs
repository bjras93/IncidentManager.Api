namespace IncidentManagement.Application.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserTypeModel UserType { get; set; }
    }
}
