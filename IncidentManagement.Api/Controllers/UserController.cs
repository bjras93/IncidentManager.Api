using IncidentManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace IncidentManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public IActionResult GetAllByType([FromBody]JObject data)
        {
            var incidents = _userService.GetAllByType(int.Parse(data["userTypeId"].ToString()), out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(incidents);
            }
            else
            {
                return StatusCode(500, error);
            }
        }
    }
}