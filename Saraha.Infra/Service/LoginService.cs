using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }
        public bool CreateLogin(Login login)
        {
            return loginRepository.CreateLogin(login);
        }

        public bool DeleteLogin(int? id)
        {
            return loginRepository.DeleteLogin(id);
        }

        public List<Login> GetallLogins()
        {
            return loginRepository.GetallLogins();
        }

        public bool UpdateActiveStatus(int isActive, int loginId)
        {
            return loginRepository.UpdateActiveStatus(isActive,loginId);
        }

        public bool UpdateBlockedStatus(int isBlocked, int loginId)
        {
            return loginRepository.UpdateBlockedStatus(isBlocked, loginId);
        }

        public bool UpdateLogin(Login login)
        {
            return loginRepository.UpdateLogin(login);
        }

        public bool UpdateVerifyStatus(int isVerified, int loginId)
        {
            return loginRepository.UpdateVerifyStatus(isVerified,loginId);
        }
    }
}
