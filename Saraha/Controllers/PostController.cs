using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saraha.Core.Data;
using Saraha.Core.DTO;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saraha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        public List<Post> GetAllPost()
        {

            return postService.GetAll();
        }
        [HttpPost]
        [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
        public void createPost([FromBody] Post aboutus)
        {
            postService.Insert(aboutus);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
        public void UpdatePost([FromBody] Post aboutus)
        {
            postService.Update(aboutus);
        }

        [HttpDelete("delete/{id}")]
        public void DeletePost(int id)
        {
            postService.Delete(id);
        }
        [HttpPut("PinPost/{id}")]
        public void PinPost(int id)
        {
            postService.PinPost(id);
        }
        [HttpGet("PostUserComments")]
        public List<PostUserComment> PostUserComments()
        {
            return postService.PostUserComments();
        }
    }
}
