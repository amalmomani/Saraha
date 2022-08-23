using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Repository
{
    public interface ILoginRepository
    {
        public List<Login> GetallLogins();
        public bool CreateLogin(Login login);
        public bool UpdateLogin(Login login);
        public bool DeleteLogin(int? id);
        public bool UpdateVerifyStatus(int isVerified,int loginId);
        public bool UpdateActiveStatus(int isActive, int loginId);
        public bool UpdateBlockedStatus(int isBlocked, int loginId);
        public Login auth(Login login);
        public Login GetLoginByUserId(int userId);
        public void ChangePassword(int loginId, string password);
       
    }
}
