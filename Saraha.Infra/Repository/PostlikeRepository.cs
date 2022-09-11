using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Saraha.Core.Common;
using Saraha.Core.Data;
using Saraha.Core.DTO;
using Saraha.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Infra.Repository
{
  public class PostlikeRepository : IPostlikeRepository
    {

        private readonly IDbcontext dbContext;
        private readonly IHubContext<MessageHub> _hubContext;

        public PostlikeRepository(IDbcontext dbContext , IHubContext<MessageHub> hubContext)
        {
            this.dbContext = dbContext;
            _hubContext = hubContext;

        }

      


        public  async void CreateLike(Postlike like , int userLogin)
        {
           
            DateTime now = DateTime.Now;
            IEnumerable<Postlike> allLikes = dbContext.Connection.Query<Postlike>("Like_package.getallLikes", commandType: CommandType.StoredProcedure);

            var exist = allLikes.Any(x => x.PostId == like.PostId && x.UserId == like.UserId);
            Postlike PostLikeUser = allLikes.Where(x => x.PostId == like.PostId && x.UserId == like.UserId).SingleOrDefault();
            if (!exist)
            {



                var parameter = new DynamicParameters();
                parameter.Add("@likeDatee",now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                parameter.Add("@userIdd", like.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("@postIdd", like.PostId, dbType: DbType.Int32, direction: ParameterDirection.Input);




                var result = dbContext.Connection.Execute("Like_package.createLike", parameter, commandType: CommandType.StoredProcedure);
                IEnumerable<Postlike> newlikes = dbContext.Connection.Query<Postlike>("Like_package.getallLikes", commandType: CommandType.StoredProcedure);


                var likeDone = newlikes.Where(x => x.PostId == like.PostId && x.UserId == like.UserId && x.LikeDate.ToString() == now.ToString() && x.UserId == userLogin).SingleOrDefault();

                //Add Like to user Activity Table

                var activity = new DynamicParameters();
                activity.Add("@UserIDD", like.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                activity.Add("@LikeIDD", likeDone.LikeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                activity.Add("@CommentIDD",null, dbType: DbType.Int32, direction: ParameterDirection.Input);
                activity.Add("@PostIDD", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
                activity.Add("@ActivityNamee", "like", dbType: DbType.String, direction: ParameterDirection.Input);
                activity.Add("@Messagee", " ", dbType: DbType.String, direction: ParameterDirection.Input);
                activity.Add("@ActivityDatee", DateTime.Now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                activity.Add("@FollowIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var r = dbContext.Connection.Execute("Activity_package_api.createActivity", activity, commandType: CommandType.StoredProcedure);

                //Add like to notifications 

                IEnumerable<Post> posts = dbContext.Connection.Query<Post>("Post_package.getallPosts", commandType: CommandType.StoredProcedure);
                var likedpost = posts.Where(p => p.Postid == likeDone.PostId).SingleOrDefault();

                var noti = new DynamicParameters();

                noti.Add("@UserIdd", likedpost.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
                IEnumerable<LikeNotificationDTO> notificationlike = dbContext.Connection.Query<LikeNotificationDTO>("Notifications_package_api.GetLikeNotificationByUserId", noti,
                  commandType: CommandType.StoredProcedure);
                var likenoti = notificationlike.Where(n => n.LikeId == likeDone.LikeId).SingleOrDefault();

                var notification = new DynamicParameters();
                notification.Add("@Messagee", likenoti.userFromImage, dbType: DbType.String, direction: ParameterDirection.Input);

                notification.Add("@MessageIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
                notification.Add("@IsRead", 0, dbType: DbType.Int32, direction: ParameterDirection.Input);


                notification.Add("@CommentIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
                notification.Add("@LikeIDD", likeDone.LikeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                notification.Add("@userFromm", likeDone.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                notification.Add("@userToo", likedpost.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
                notification.Add("@ReportIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
                notification.Add("@PostIdd", likedpost.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);

                notification.Add("@NotDate", now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                notification.Add("@FollowIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
                notification.Add("@Ntype", "like", dbType: DbType.String, direction: ParameterDirection.Input);
                notification.Add("@NotificationTextt", likenoti.UserFrom+ " Liked Your Post", dbType: DbType.String, direction: ParameterDirection.Input);

                var not = dbContext.Connection.Execute("Notifications_package_api.createNotfication", notification, commandType: CommandType.StoredProcedure);






               
                if (likenoti != null)
                {
                    likenoti.NotificationText = "likes your post";
                    await _hubContext.Clients.All.SendAsync("MessageReceived", likenoti );
                        var paramete = new DynamicParameters();
                           paramete.Add("@UserIdd", like.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);

                             IEnumerable<Notifications> nots = dbContext.Connection.Query<Notifications>("Notifications_package_api.GetNotificationByUserId", paramete, commandType: CommandType.StoredProcedure);
                              await _hubContext.Clients.All.SendAsync("NotificationReceived", nots);
                    var notsCount = nots.Where(x => x.Is_Read == 0).ToList().Count();
                                await _hubContext.Clients.All.SendAsync("NotCount", notsCount) ;

                }

            }
            else
                DeleteLike(PostLikeUser.LikeId);

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

        public List<Postlike> GetLikeById(int userId)
        {
            var p = new DynamicParameters();

            p.Add("@UserIdd", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Postlike> result = dbContext.Connection.Query<Postlike>("UserPostLike_Package.GetLikeById", p,
              commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        public bool CheckIfLiked(int userId , int postId)
        {
            IEnumerable<Postlike> result = dbContext.Connection.Query<Postlike>("Like_package.getallLikes", commandType: CommandType.StoredProcedure);
            var IsLiked = result.Any(l => l.UserId == userId && l.PostId==postId);
                return IsLiked;
        }

        public void DeleteLikeByUserPostId(int userId, int postId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@UserIdd", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@PostIdd", postId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Like_package.DeleteLikeByUserPostId", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
