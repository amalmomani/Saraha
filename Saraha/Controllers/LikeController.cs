﻿using Microsoft.AspNetCore.Http;
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
    public class LikeController : ControllerBase
    {
        private readonly IPostlikeService likeService;
        public LikeController(IPostlikeService likeService)
        {
            this.likeService = likeService;
        }


        [HttpPost("CreateLike")]
        public void RemoveLike(Postlike like)
        {
            likeService.CreateLike(like);
        }

        [HttpGet("GetLikes")]
        public List<Postlike> GetAllLikes()
        {
            return likeService.GetAllLikes();
        }

        [HttpDelete("RemoveLike/{id}")]
        public void RemoveLike(int id)
        {
             likeService.DeleteLike(id);  
        }


    }
}