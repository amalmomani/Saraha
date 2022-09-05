using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saraha.Core.Data;
using Saraha.Core.DTO;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpGet("GetPostByUserId/{userId}")]
        public List<PostFullDataDTO> GetPost(int userId)
        {

            return postService.GetPostByUserId(userId);
        }
        [HttpGet("GetPostLikedByPostId/{postId}")]
        public List<PostLikesDTO> GetLikes(int postId)
        {

            return postService.GetPostLikedBy(postId);
        }
        [HttpPost("CreatePost")]
        public void createPost([FromBody] Post post)
        {
            postService.Insert(post);
        }
        [HttpGet("MsgToPost/{msg}/{userId}/{Reply}")]
        [ProducesResponseType(typeof(Message), StatusCodes.Status200OK)]

        public void MessageToPost(string msg, int userId, string Reply)
        {
            Message m = new Message();
            m.MessageContent = msg;
            m.UserTo = userId;
           
            postService.MessageToPost(m,Reply);
        }
        [HttpPost("UploadPostImage")]
        public Post UploadPostImage()
        {

            try
            {
                var file = Request.Form.Files[0];
                byte[] fileContent;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileContent = ms.ToArray();
                }
                var fileName = Guid.NewGuid() + "_" + Path.GetFileNameWithoutExtension(file.FileName);
                string attachmentFileName = $"{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";

                var fullPath = Path.Combine("C:\\Users\\C_ROAD\\Desktop\\SARAHA - Final\\Saraha\\src\\assets", attachmentFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Post item = new Post();
                item.Imagepath = attachmentFileName;
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
        public void UpdatePost([FromBody] Post post)
        {
            postService.Update(post);
        }

        [HttpDelete("delete/{id}")]
        public void DeletePost(int id)
        {
            postService.Delete(id);
        }
        [HttpGet("PinPost/{id}/{isPin}")]
        public void PinPost(int id,int isPin)
        {
            postService.PinPost(id, isPin);
        }
        [HttpGet("PostUserComments")]
        public List<PostUserComment> PostUserComments()
        {
            return postService.PostUserComments();
        }
        [HttpGet("PostByUser/{postId}")]

        public Post GetPosById(int postId)
        {
            return postService.GetPosById(postId);
        }
        [HttpGet("CommentsByUser/{postId}")]
        public List<PostUserComment> CommentsByUser(int postId)
        {
            return postService.CommentsByUser(postId);
        }
        [HttpGet("Top3Post/{userid}")]
        public List<PostFullDataDTO> Top3Post(int userid)
        {
            return postService.Top3Post(userid);
        }
    }
}
