using CohesionIB.ApiEnginner.CodeChallenge.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionIB.ApiEnginner.CodeChallenge.Repository
{
    public class Repository : IRepository
    {
        private MyContext _myContext;

        public Repository(MyContext myContext)
        {
            _myContext = myContext;
        }
        public List<User> GetAllUsers()
        {
            return _myContext.Users.ToList();
        }
        public void UpdateTermsCondition(User user)
        {
            _myContext.Users.Update(user);
            _myContext.SaveChanges();
        }
        public User GetUserByUserName(string userName)
        {
            return _myContext.Users.FirstOrDefault(x => x.UserName.Equals(userName));
        }
        public Device GetDeviceDetailsByDeviceId(long deviceID)
        {
            return _myContext.Devices.FirstOrDefault(x => x.DeviceID == deviceID);
        }
        public void RegisterDevice(UserInvitationCode userInvitationCode)
        {
            _myContext.UserInvitationCodes.Update(userInvitationCode);
            _myContext.SaveChanges();
        }
        public UserInvitationCode GetUserInvitationCodeByCode(ulong invitationCode)
        {
            return _myContext.UserInvitationCodes.FirstOrDefault(x => x.InvitationCode == invitationCode);
        }
        public void SaveInvitationCode(UserInvitationCode userInvitationCode)
        {
            _myContext.UserInvitationCodes.Add(userInvitationCode);
            _myContext.SaveChanges();
        }
        public List<UserInvitationCode> GetUserInvitationCodes()
        {
            return _myContext.UserInvitationCodes.ToList();
        }
    }
}
