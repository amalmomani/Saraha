using Dapper;
using Saraha.Core.Common;
using Saraha.Core.Data;
using Saraha.Core.DTO;
using Saraha.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Saraha.Infra.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly IDbcontext dbContext;

        public PostRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Delete(int id)
        {
            IEnumerable<Activity> resultActivity = dbContext.Connection.Query<Activity>("Activity_package_api.getallActivity", commandType: CommandType.StoredProcedure);

            var activi = resultActivity.Where(x => x.PostId == id).SingleOrDefault();
            var parameter1 = new DynamicParameters();
            parameter1.Add("@ActivityIDD", activi.ActivityID, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var resultdelet = dbContext.Connection.ExecuteAsync("Activity_package_api.deleteActivity", parameter1, commandType: CommandType.StoredProcedure);

            var parameter = new DynamicParameters();
            parameter.Add("@postIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Post_package.deletePost", parameter, commandType: CommandType.StoredProcedure);

        }

        public List<Post> GetAll()
        {
            IEnumerable<Post> result = dbContext.Connection.Query<Post>("Post_package.getallPosts", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<PostFullDataDTO> GetPostByUserId(int userId)
        {

            var parameter = new DynamicParameters();
            parameter.Add("userIdd", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<PostFullDataDTO> result = dbContext.Connection.Query<PostFullDataDTO>("Post_package.GetPostInfoByUserId", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();


        }
        public List<PostLikesDTO> GetPostLikedBy(int postId)
        {

            var parameter = new DynamicParameters();
            parameter.Add("postIdd", postId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<PostLikesDTO> result = dbContext.Connection.Query<PostLikesDTO>("DTOPackage.PostLikes", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();


        }
        public List<PostFullDataDTO> Top3Post(int userid)
        {

            var parameter = new DynamicParameters();
            parameter.Add("userIdd", userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<PostFullDataDTO> result = dbContext.Connection.Query<PostFullDataDTO>("Top3Post", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();


        }

        public void Insert(Post post)
        {
            DateTime now = DateTime.Now;
          
            var parameter = new DynamicParameters();
            parameter.Add("@postDatee", now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@postTextt", post.Posttext, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@ImagePathh", post.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@userIdd", post.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@postTypee", "post", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Replyy", " ", dbType: DbType.String, direction: ParameterDirection.Input);



            var result = dbContext.Connection.Execute("Post_package.createPost", parameter, commandType: CommandType.StoredProcedure);
            IEnumerable<Post> posts = dbContext.Connection.Query<Post>("Post_package.getallPosts", commandType: CommandType.StoredProcedure);
            
            var p = posts.Where(p => p.Posttext == post.Posttext && p.Userid==post.Userid && p.Postdate.ToString() == now.ToString()  ).SingleOrDefault();
            var pa = new DynamicParameters();
            pa.Add("@UserIDD", post.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@LikeIDD", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@CommentIDD", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@PostIDD", p.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@ActivityNamee", "post", dbType: DbType.String, direction: ParameterDirection.Input);
            pa.Add("@Messagee", post.Posttext, dbType: DbType.String, direction: ParameterDirection.Input);
            pa.Add("@ActivityDatee", DateTime.Now, dbType: DbType.DateTime, direction: ParameterDirection.Input);



            var r = dbContext.Connection.Execute("Activity_package_api.createActivity", pa, commandType: CommandType.StoredProcedure);

        }
        public void MessageToPost(Message msg, string Reply)
        {
            DateTime now = DateTime.Now;

            var parameter = new DynamicParameters();
            parameter.Add("@postDatee", now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@postTextt", msg.MessageContent, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@ImagePathh", null, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@userIdd", msg.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@postTypee", "msg", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Replyy", Reply, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Post_package.createPost", parameter, commandType: CommandType.StoredProcedure);
            IEnumerable<Post> posts = dbContext.Connection.Query<Post>("Post_package.getallPosts", commandType: CommandType.StoredProcedure);

            var p = posts.Where(p => p.Posttext == msg.MessageContent && p.Userid == msg.UserTo && p.Postdate.ToString() == now.ToString()).SingleOrDefault();
            var pa = new DynamicParameters();
            pa.Add("@UserIDD", msg.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@LikeIDD", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@CommentIDD", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@PostIDD", p.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@ActivityNamee", "post", dbType: DbType.String, direction: ParameterDirection.Input);
            pa.Add("@Messagee", msg.MessageContent, dbType: DbType.String, direction: ParameterDirection.Input);

            var r = dbContext.Connection.Execute("Activity_package_api.createActivity", pa, commandType: CommandType.StoredProcedure);

        }


        public void PinPost(int id , int isPin)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@postIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@isPin", isPin, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("Post_package.PinPost", parameter, commandType: CommandType.StoredProcedure);

        }

        public void Update(Post post)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@postIdd", post.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //parameter.Add("@postDatee", post.Postdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@postTextt", post.Posttext, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@ImagePathh", post.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
          //  parameter.Add("@userIdd", post.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Post_package.UpdatePost", parameter, commandType: CommandType.StoredProcedure);
        }
        public List<PostUserComment> PostUserComments()
        {
            IEnumerable<PostUserComment> result = dbContext.Connection.Query<PostUserComment>("DTOPackage.PostUserComment", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<PostUserComment> CommentsByUser(int postId)
        {
            IEnumerable<PostUserComment> result = dbContext.Connection.Query<PostUserComment>("DTOPackage.PostUserComment", commandType: CommandType.StoredProcedure);

            var Comment = result.Where(x => x.postId == postId);
            return Comment.ToList();
        }

    }
}
