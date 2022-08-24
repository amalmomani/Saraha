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
            var parameter = new DynamicParameters();
            parameter.Add("@postIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Post_package.deletePost", parameter, commandType: CommandType.StoredProcedure);

        }

        public List<Post> GetAll()
        {
            IEnumerable<Post> result = dbContext.Connection.Query<Post>("Post_package.getallPosts", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Post> GetPostByUserId(int userId)
        {

            var parameter = new DynamicParameters();
            parameter.Add("userIdd", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Post> result = dbContext.Connection.Query<Post>("Activity_package_api.GetPostByUserId", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();


        }


        public void Insert(Post post)
        {
            DateTime now = DateTime.Now;
          
            var parameter = new DynamicParameters();
            parameter.Add("@postDatee", now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@postTextt", post.Posttext, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@ImagePathh", post.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@userIdd", 21, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Post_package.createPost", parameter, commandType: CommandType.StoredProcedure);
            IEnumerable<Post> posts = dbContext.Connection.Query<Post>("Post_package.getallPosts", commandType: CommandType.StoredProcedure);
            
            var p = posts.Where(p => p.Posttext == post.Posttext && p.Userid==21 && p.Postdate.ToString() == now.ToString()  ).SingleOrDefault();
            var pa = new DynamicParameters();
            pa.Add("@UserIDD", 21, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@LikeIDD", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@CommentIDD", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@PostIDD", p.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@ActivityNamee", "post", dbType: DbType.String, direction: ParameterDirection.Input);
            pa.Add("@Messagee", post.Posttext, dbType: DbType.String, direction: ParameterDirection.Input);



            var r = dbContext.Connection.Execute("Activity_package_api.createActivity", pa, commandType: CommandType.StoredProcedure);

        }

        public void PinPost(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@postIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

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
    }
}
