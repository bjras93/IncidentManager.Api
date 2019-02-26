﻿using IncidentManagement.Application.Interfaces;
using IncidentManagement.Application.Logic;
using IncidentManagement.Application.Models;
using IncidentManagement.Repository.DTO;
using IncidentManagement.Repository.Interfaces;

namespace IncidentManagement.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IUserTypeRepository _userTypeRepository;
        private PasswordHelper _passwordHelper = new PasswordHelper();
        public UserService(IUserRepository userRepository, IUserTypeRepository userTypeRepository)
        {
            _userRepository = userRepository;
            _userTypeRepository = userTypeRepository;
        }
        public UserModel GetUser(int userId, out string error)
        {
            try
            {
                var user = _userRepository.FindBy(up => up.Id == userId).Result;
                error = "";
                return new UserModel { Id = user.Id, Name = user.Name };
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;                
            }
        }
        public UserModel CreateUser(string email, string password, string name, int typeId, out string error)
        {
            try
            {
                var userType = _userTypeRepository.FindBy(ut => ut.Id == typeId).Result;
                var pw = _passwordHelper.HashPassword(password);
                var user = new User
                {
                    Email = email,
                    Password = pw.Hash,
                    Salt = pw.Salt,
                    UserType = userType,
                    Name = name
                };
                var created = _userRepository.Add(user).Result;
                _userRepository.SaveChanges();
                error = "";
                return new UserModel { Id = user.Id, Name = user.Name };
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }            
        }

        public UserModel Login(string email, string password, out string error)
        {
            try
            {
                var user = _userRepository.FindBy(up => up.Email == email).Result;
                var verifyPassword = _passwordHelper.VerifyPassword(password, user.Salt);
                var validUser = _userRepository.FindBy(u => u.Password == verifyPassword.Hash && u.Salt == verifyPassword.Salt).Result;
                error = "";
                return new UserModel { Id = validUser.Id, Name = validUser.Name };
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }
        }
    }
}
