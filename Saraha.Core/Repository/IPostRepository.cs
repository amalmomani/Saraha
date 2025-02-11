﻿using Saraha.Core.Data;
using Saraha.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Repository
{
    public interface IPostRepository
    {
        public void Insert(Post post);
        public void Update(Post post);

        public void Delete(int id);

        public List<Post> GetAll();
        public void PinPost(int id, int isPin);
        public List<PostUserComment> PostUserComments();
        public List<PostFullDataDTO> GetPostByUserId(int userId);
        public List<PostUserComment> CommentsByUser(int postId);

        public List<PostLikesDTO> GetPostLikedBy(int postId);
        public void MessageToPost(Message msg, string Reply);
        public Post GetPosById(int postId);

        public List<PostFullDataDTO> Top3Post(int userid);

    }
}
