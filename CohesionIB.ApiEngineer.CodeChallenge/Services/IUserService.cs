using CohesionIB.ApiEnginner.CodeChallenge.Repository;
using CohesionIB.ApiEnginner.CodeChallenge.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CohesionIB.ApiEngineer.CodeChallenge.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        List<User> GetUsers();
        void UpdateTermsAndCondition(User user);
        User GetUserByUserName(string userName);
        Device GetDeviceDetailsByDeviceId(long deviceId);
        void RegisterDevice(UserInvitationCode userInvitationCode);
        UserInvitationCode GetUserInvitationCodeByCode(ulong invitationCode);
        void SaveInvitationCode(UserInvitationCode userInvitationCode);
        List<UserInvitationCode> GetUserInvitationCodes();
    }

    public class UserService : IUserService
    {
        private readonly IRepository repository;
        public UserService(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            var users = GetUsers();
            var user = users.FirstOrDefault(x => x.UserName == username && x.Password == password);
            return user;
        }

        public List<User> GetUsers()
        {
            return repository.GetAllUsers();
        }
        public void UpdateTermsAndCondition(User user)
        {
            repository.UpdateTermsCondition(user);
        }
        public User GetUserByUserName(string userName)
        {
            return repository.GetUserByUserName(userName);
        }
        public Device GetDeviceDetailsByDeviceId(long deviceId)
        {
            return repository.GetDeviceDetailsByDeviceId(deviceId);
        }
        public void RegisterDevice(UserInvitationCode userInvitationCode)
        {
            repository.RegisterDevice(userInvitationCode);
        }
        public UserInvitationCode GetUserInvitationCodeByCode(ulong invitationCode)
        {
            return repository.GetUserInvitationCodeByCode(invitationCode);
        }

        public void SaveInvitationCode(UserInvitationCode userInvitationCode)
        {
            repository.SaveInvitationCode(userInvitationCode);
        }

        public List<UserInvitationCode> GetUserInvitationCodes()
        {
            return repository.GetUserInvitationCodes();
        }

    }
}
