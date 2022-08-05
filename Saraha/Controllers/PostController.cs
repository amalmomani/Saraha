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
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        public List<Post> getallPost()
        {

            return postService.getall();
        }
        [HttpPost]
        [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
        public void createPost([FromBody] Post aboutus)
        {
            postService.insert(aboutus);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
        public void UpdatePost([FromBody] Post aboutus)
        {
            postService.update(aboutus);
        }

        [HttpDelete("delete/{id}")]
        public void deletePost(int id)
        {
            postService.delete(id);
        }

    }
}
