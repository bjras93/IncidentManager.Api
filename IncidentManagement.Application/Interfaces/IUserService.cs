using IncidentManagement.Application.Models;
using System.Collections.Generic;

namespace IncidentManagement.Application.Interfaces
{
    public interface IUserService
    {
        UserModel GetUser(int userId, out string error);
        UserModel CreateUser(string email, string password, string name, int typeId, out string error);
        UserModel Login(string email, string password, out string error);
        List<UserModel> GetAllByType(int userTypeId, out string error);
    }
}
