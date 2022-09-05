using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saraha.Core.Data;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;
        
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpGet]
        public List<Login> GetallLogins()
        {
            return loginService.GetallLogins();
        }

        [HttpPost("log")]
        public bool CreateLogin([FromBody]Login login)
        {
            return loginService.CreateLogin(login);
        }

        [HttpPut]
        public bool UpdateLogin([FromBody]Login login)
        {
            return loginService.UpdateLogin(login);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool DeleteLogin(int? id)
        {
            return loginService.DeleteLogin(id);
        }

        [HttpGet]
        [Route("UpdateVerifyStatus/{isVerified}/{loginId}")]
        public bool UpdateVerifyStatus(int isVerified, int loginId)
        {
            return loginService.UpdateVerifyStatus(isVerified, loginId);
        }

        [HttpGet]
        [Route("UpdateActiveStatus/{isActive}/{loginId}")]
        public bool UpdateActiveStatus(int isActive, int loginId)
        {
            return loginService.UpdateActiveStatus(isActive, loginId);
        }

        [HttpGet]
        [Route("UpdateBlockedStatus/{isBlocked}/{loginId}")]
        public bool UpdateBlockedStatus(int isBlocked, int loginId)
        {
            return loginService.UpdateBlockedStatus(isBlocked, loginId);
        }

        [HttpPost("Login")]
        public IActionResult auth([FromBody] Login login)
        {
            var RESULT = loginService.auth(login);
             
            if (RESULT == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(RESULT);
            }
        }

        [HttpGet("GetLoginByUserId/{userId}")]
        public Login GetLoginByUserId(int userId)
        {
            return loginService.GetLoginByUserId(userId);
        }

        [HttpGet("ChangePassword/{loginId}/{password}")]
        public void ChangePassword(int loginId, string password)
        {
            loginService.ChangePassword(loginId, password);
        }

        [HttpGet("SendVerfiyCodeEmail/{email}")]
        public int SendVerfiyCodeEmail(String email)
        {
            Random rand = new Random();

           int codeVerfiy = rand.Next(100000, 999999);
            string to = email; //To address    
            string from = "rawanazzam68@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "this is code to verfiy Eamil \n" + codeVerfiy;
            message.Subject = "Saraha Verfiy Email";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            try
            {
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("rawanazzam68@gmail.com", "yugxqzeqsferfxoz");
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                }
                return codeVerfiy;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("GetLoginIdByEmail/{email}")]
        public int GetLoginIdByEmail(string email)
        {
            return loginService.GetLoginIdByEmail(email);
        }


    }
}
