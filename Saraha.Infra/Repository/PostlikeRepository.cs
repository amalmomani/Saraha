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
  public class PostlikeRepository : IPostlikeRepository
    {

        private readonly IDbcontext dbContext;

        public PostlikeRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void CreateLike(Postlike post)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@likeDatee", DateTime.Now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@userIdd", post.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@postIdd", post.PostId, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("Like_package.createLike", parameter, commandType: CommandType.StoredProcedure);

        }

        public List<Postlike> GetAllLikes()
        {
            IEnumerable<Postlike> result = dbContext.Connection.Query<Postlike>("Like_package.getallLikes", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public void DeleteLike(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@likeIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Like_package.DeleteLike", parameter, commandType: CommandType.StoredProcedure);
        }

        public List<PostLikesDTO> GetPostLikes()
        {
            IEnumerable<PostLikesDTO> result = dbContext.Connection.Query<PostLikesDTO>("DTOPackage.PostLikes", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
