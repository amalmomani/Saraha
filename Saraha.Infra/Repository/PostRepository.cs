﻿using Dapper;
using Saraha.Core.Common;
using Saraha.Core.Data;
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
        public void delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@postIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Post_package.deletePost", parameter, commandType: CommandType.StoredProcedure);

        }

        public List<Post> getall()
        {
            IEnumerable<Post> result = dbContext.Connection.Query<Post>("Post_package.getallPosts", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void insert(Post post)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@postDatee", post.Postdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@postTextt", post.Posttext, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@ImagePathh", post.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@userIdd", post.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Post_package.createPost", parameter, commandType: CommandType.StoredProcedure);
        }

        public void update(Post post)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@postIdd", post.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //parameter.Add("@postDatee", post.Postdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@postTextt", post.Posttext, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@ImagePathh", post.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
          //  parameter.Add("@userIdd", post.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Post_package.UpdatePost", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
