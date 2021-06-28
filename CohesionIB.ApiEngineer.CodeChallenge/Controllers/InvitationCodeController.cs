using CohesionIB.ApiEngineer.CodeChallenge.Services;
using CohesionIB.ApiEnginner.CodeChallenge.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CohesionIB.ApiEngineer.CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InvitationCodeController : ControllerBase
    {
        private IInvitationCodeService _invitationCodeService;
        private IUserService _userService;

        public InvitationCodeController(IInvitationCodeService invitationCodeService, IUserService userService)
        {
            _invitationCodeService = invitationCodeService;
            _userService = userService;
        }

        [HttpGet]
        [Route("acceptTerms")]
        public IActionResult AcceptTerms()
        {
            var userName = HttpContext.User.Identities.FirstOrDefault().Name;
            var user = _userService.GetUserByUserName(userName);
            if (user != null)
            {
                user.IsTermsAccepted = true;
                _userService.UpdateTermsAndCondition(user);
                return Ok("Terms and Conditions Accepeted Successfully");
            }
            return Ok();
        }

        [HttpGet]
        [Route("getinvitationcode")]
        public IActionResult Get()
        {
            var userName = HttpContext.User.Identities.FirstOrDefault().Name;
            var user = _userService.GetUserByUserName(userName);
            if (user != null && !user.IsTermsAccepted)
                return Unauthorized();

            if (!_invitationCodeService.HasCode)
                return NoContent();
            if (_invitationCodeService.HasCode)
            {
                var userInvitationCode = new UserInvitationCode()
                {
                    UserId = user.UserId,
                    InvitationCode = _invitationCodeService.Code,
                };
                _userService.SaveInvitationCode(userInvitationCode);
            }

            return Ok(new { _invitationCodeService.Code });
        }

        /// <summary>
        /// Use an invitation code to assign a device id to a user
        /// </summary>
        /// <param name="code">A invitation code that was returned</param>
        /// <param name="deviceId">The device id to associate with the user.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("registerDevice")]
        public IActionResult Put(ulong code, long deviceId)
        {
            //check if the invitation code is already being used
            var userInvitationCode = _userService.GetUserInvitationCodeByCode(code);
            var userName = HttpContext.User.Identities.FirstOrDefault().Name;
            var currentUser = _userService.GetUserByUserName(userName);
            if (userInvitationCode != null && userInvitationCode.DeviceId.HasValue)
            {
                return Ok("This Invitation code is already being used");
            }
            if (userInvitationCode != null && userInvitationCode.UserId != currentUser.UserId)
            {
                return Ok("Invitation Code used is not associated for the user" + " " + currentUser.UserName);
            }
            var deviceDetails = _userService.GetDeviceDetailsByDeviceId(deviceId);
            // check for device id to be unique for user
            if (currentUser.UserId != deviceDetails.User.UserId)
            {
                return Conflict();
            }
            //Register Device
            if (userInvitationCode != null)
            {
                userInvitationCode.DeviceId = deviceId;
                _userService.RegisterDevice(userInvitationCode);
                return Ok();
            }
            else
            {
                return Ok("Please enter the correct Invitation code");
            }
        }
    }
}
