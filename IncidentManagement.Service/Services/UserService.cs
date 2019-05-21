using AutoMapper;
using IncidentManagement.Application.Interfaces;
using IncidentManagement.Application.Logic;
using IncidentManagement.Domain;
using IncidentManagement.Repository.Interfaces;
using System.Collections.Generic;

namespace IncidentManagement.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IUserTypeRepository _userTypeRepository;
        private PasswordHelper _passwordHelper = new PasswordHelper();
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IUserTypeRepository userTypeRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _userTypeRepository = userTypeRepository;
            _mapper = mapper;
        }
        public User GetUser(int userId, out string error)
        {
            try
            {
                var user = _userRepository.FindBy(up => up.Id == userId).Result;
                error = "";
                return new User { Id = user.Id, Name = user.Name };
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;                
            }
        }
        public User CreateUser(string email, string name, int typeId, out string error)
        {
            try
            {
                var userType = _userTypeRepository.FindBy(ut => ut.Id == typeId).Result;
                var user = new User
                {
                    Email = email,
                    UserType = userType,
                    Name = name
                };
                var added = _userRepository.Add(user).Result;
                if (added)
                {
                    _userRepository.SaveChanges();
                    error = "";
                }
                else
                {
                    error = "User already added";
                }
                return _mapper.Map<User>(user);
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }            
        }

        public User Login(string email, string password, out string error)
        {
            try
            {
                var user = _userRepository.FindBy(up => up.Email == email).Result;
                if(string.IsNullOrEmpty(user.Password))
                {
                    var pw = _passwordHelper.HashPassword(password);
                    user.Password = pw.Hash;
                    user.Salt = pw.Salt;
                    _userRepository.Update(user);
                    _userRepository.SaveChanges();
                }
                var verifyPassword = _passwordHelper.VerifyPassword(password, user.Salt);
                var validUser = _userRepository.FindBy(u => u.Password == verifyPassword.Hash && u.Salt == verifyPassword.Salt, (u => u.UserType)).Result;
                var mappedUser = _mapper.Map<User>(validUser);
                error = "";
                return mappedUser;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }
        }
        public List<User> GetAllByType(int userTypeId, out string error)
        {
            try
            {
                var incidents = _userRepository.AllByType(userTypeId).Result;
                var result = _mapper.Map<List<User>>(incidents);
                error = "";
                return result;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }

        }
    }
}
