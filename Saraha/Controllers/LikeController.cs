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
    public class LikeController : ControllerBase
    {
        private readonly IPostlikeService likeService;
        public LikeController(IPostlikeService likeService)
        {
            this.likeService = likeService;
        }


        [HttpGet("CreateLike/{userId}/{postId}/{userLogIn}")]
        public void CreateLike(int userId ,int postId,int userLogIn)
        {
            Postlike like = new Postlike();
            like.PostId = postId;
            like.UserId = userId;
            likeService.CreateLike(like, userLogIn);
        }

        [HttpGet("GetLikes")]
        public List<Postlike> GetAllLikes()
        {
            return likeService.GetAllLikes();
        }
        [HttpGet("PostLikes")]
        public List<PostLikesDTO> GetPostLikes()
        {
            return likeService.GetPostLikes();
        }

        [HttpDelete("RemoveLike/{id}")]
        public void RemoveLike(int id)
        {
             likeService.DeleteLike(id);  
        }

        [HttpGet("Likescount/{userId}")]
        public List<Postlike> GetLikeById(int userId)
        {
            return likeService.GetLikeById(userId);
        }
        [HttpGet("IsLike/{userId}/{postId}")]
        public bool IsLiked(int userId,int postId)
        {
            return likeService.CheckIfLiked(userId , postId);
        }
    }
}
