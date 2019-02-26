using IncidentManagement.Application.Interfaces;
using IncidentManagement.Application.Models;
using IncidentManagement.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace IncidentManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public IActionResult Authenticate([FromBody]JObject data)
        {
            string error = "";
            try
            {
                return Ok(_userService.Login(data["email"].ToString(), data["password"].ToString(), out error));
            }
            catch (System.Exception)
            {
                return StatusCode(500, error);
            }
        }
        [HttpPost]
        public IActionResult Create(string email, string password, string name, int typeId)
        {

            string error = "";
            var user = _userService.CreateUser(email, password, name, typeId, out error);
            if (!string.IsNullOrEmpty(error))
            {
                return Ok(user);
            }
            else
            {
                return StatusCode(500, error);
            }
        }

    }
}