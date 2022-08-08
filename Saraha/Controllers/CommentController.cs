using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saraha.Core.Data;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saraha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IPostcommentService commentservice;
        public CommentController(IPostcommentService commentservice)
        {
            this.commentservice = commentservice;
        }
        [HttpGet("GetComments")]
        public List<Postcomment> GetCommnets()
        {

            return commentservice.GetAllComments();
        }
        [HttpPost]
        public void CreateComment([FromBody] Postcomment comment)
        {
            commentservice.CreateComment(comment);
        }

        [HttpPut ("UpdateComment/{id}")]
        public void UpdateComment([FromBody] Postcomment comment , int id)
        {
            commentservice.UpdateComment(comment , id);
        }

        [HttpDelete("RemoveComment/{id}")]
        public void DeleteComment(int id)
        {
            commentservice.DeleteComment(id);
        }


    }
}
