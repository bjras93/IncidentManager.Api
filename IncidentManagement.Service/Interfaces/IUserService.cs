using IncidentManagement.Domain;
using System.Collections.Generic;

namespace IncidentManagement.Application.Interfaces
{
    public interface IUserService
    {
        User GetUser(int userId, out string error);
        User CreateUser(string email, string name, int typeId, out string error);
        User Login(string email, string password, out string error);
        List<User> GetAllByType(int userTypeId, out string error);
    }
}
