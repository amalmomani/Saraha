using Microsoft.IdentityModel.Tokens;
using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Saraha.Infra.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository loginRepository;
        private readonly IRoleRepository repo;
        public LoginService(ILoginRepository loginRepository, IRoleRepository repo)
        {
            this.loginRepository = loginRepository;
            this.repo = repo;
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

        public string auth(Login login)
        {
            var result = loginRepository.auth(login);
            //var result2 = repo.GetallRoles(role);
            if (result == null)
            {
                return null;
            }


            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]");
            var tokenDescirptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Name, result.Username),
                   new Claim("UserId", result.Userid.ToString()),
                   new Claim("is_Blocked", result.Is_Blocked.ToString()),
                   new Claim("Is_Verified", result.Is_Verified.ToString()),
                   new Claim("loginId", result.Loginid.ToString()),
                   new Claim(ClaimTypes.Role, result.Roleid.ToString()),

                }
                ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)


            };

            var generatetoken = tokenhandler.CreateToken(tokenDescirptor);
            return tokenhandler.WriteToken(generatetoken);
        }

        public Login GetLoginByUserId(int userId)
        {
            return loginRepository.GetLoginByUserId(userId);
        }

        public void ChangePassword(int loginId, string password)
        {
             loginRepository.ChangePassword(loginId, password);
        }

        
    }
}

