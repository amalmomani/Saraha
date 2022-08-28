using Saraha.Core.Data;
using Saraha.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Service
{
    public interface IPostService
    {
        public void Insert(Post post);
        public void Update(Post post);

        public void Delete(int id);

        public List<Post> GetAll();
        public void PinPost(int id, int isPin);
        public List<PostUserComment> PostUserComments();
        public List<PostFullDataDTO> GetPostByUserId(int userId);
        public List<PostLikesDTO> GetPostLikedBy(int postId);
        public void MessageToPost(Message msg, string Reply);






    }
}
