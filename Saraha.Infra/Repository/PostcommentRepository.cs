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
   public class PostcommentRepository : IPostcommentRepository
    {
        private readonly IDbcontext dbContext;

        public PostcommentRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void DeleteComment(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@commentIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Comment_package.deleteComment", parameter, commandType: CommandType.StoredProcedure);

        }

        public List<Postcomment> GetAllComments()
        {
            IEnumerable<Postcomment> result = dbContext.Connection.Query<Postcomment>("Comment_package.getallComments", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateComment(Postcomment comment)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@commentDatee", DateTime.Now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@userIdd", comment.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@postidd", comment.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@commentTextt", comment.Commenttext, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@imagePathh", comment.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("Comment_package.createComment", parameter, commandType: CommandType.StoredProcedure);
        }

   

        public void UpdateComment(Postcomment Comment , int id )
        {
            var parameter = new DynamicParameters();
            parameter.Add("@commentIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@commentText", Comment.Commenttext, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@imagePathh", Comment.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Comment_package.UpdateComment", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}