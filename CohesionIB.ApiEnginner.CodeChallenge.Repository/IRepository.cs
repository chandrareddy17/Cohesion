using CohesionIB.ApiEnginner.CodeChallenge.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CohesionIB.ApiEnginner.CodeChallenge.Repository
{
    public interface IRepository
    {
        List<User> GetAllUsers();
        void UpdateTermsCondition(User user);
        User GetUserByUserName(string userName);
        Device GetDeviceDetailsByDeviceId(long deviceID);
        void RegisterDevice(UserInvitationCode userInvitationCode);
        UserInvitationCode GetUserInvitationCodeByCode(ulong invitationCode);
        void SaveInvitationCode(UserInvitationCode userInvitationCode);
        List<UserInvitationCode> GetUserInvitationCodes();
    }
}
