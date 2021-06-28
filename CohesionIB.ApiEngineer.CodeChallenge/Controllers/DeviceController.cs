using CohesionIB.ApiEngineer.CodeChallenge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CohesionIB.ApiEngineer.CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DeviceController : ControllerBase
    {
        private IUserService _userService;

        public DeviceController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("getRegisteredCodes")]
        public IActionResult Get()
        {
            var userName = HttpContext.User.Identities.FirstOrDefault().Name;
            var currentUser = _userService.GetUserByUserName(userName);
            var userInvitationCodes = _userService.GetUserInvitationCodes();
            var registeredCurrentInvitationCodes = userInvitationCodes.Where(x => x.UserId == currentUser.UserId && x.DeviceId.HasValue);
            if (registeredCurrentInvitationCodes.Count() > 0)
            {
                return Ok(new { registeredCurrentInvitationCodes });
            }
            return Ok("No Regsitered Devices available for current user");
        }
    }
}
