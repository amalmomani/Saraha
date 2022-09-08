using Dapper;
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

namespace Saraha.Infra.Repository
{
   public class PostcommentRepository : IPostcommentRepository
    {
        private readonly IDbcontext dbContext;
        private readonly IHubContext<MessageHub> hubContext;

        public PostcommentRepository(IDbcontext dbContext , IHubContext<MessageHub> hubContext)
        {
            this.dbContext = dbContext;
            this.hubContext = hubContext;
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

        public async void CreateComment(Postcomment comment)
        {
            DateTime now = DateTime.Now;
            var parameter = new DynamicParameters();
            parameter.Add("@commentDatee", DateTime.Now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@userIdd", comment.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@postidd", comment.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@commentTextt", comment.Commenttext, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@imagePathh", comment.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("Comment_package.createComment", parameter, commandType: CommandType.StoredProcedure);
            IEnumerable<Postcomment> comments = dbContext.Connection.Query<Postcomment>("Comment_package.getallComments", commandType: CommandType.StoredProcedure);
            var comm = comments.Where(c => c.Commenttext == comment.Commenttext && c.Userid == comment.Userid && c.Commentdate.ToString() == now.ToString()).SingleOrDefault();
            var pa = new DynamicParameters();
            pa.Add("@UserIDD", comment.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@LikeIDD", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@CommentIDD", comm.Commentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@PostIDD", comm.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@ActivityNamee", "comment", dbType: DbType.String, direction: ParameterDirection.Input);
            pa.Add("@Messagee", comm.Commenttext, dbType: DbType.String, direction: ParameterDirection.Input);
            pa.Add("@ActivityDatee", DateTime.Now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            pa.Add("@FollowIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var r = dbContext.Connection.Execute("Activity_package_api.createActivity", pa, commandType: CommandType.StoredProcedure);



            //Add commment to notifications
            var noti = new DynamicParameters();
            IEnumerable<Post> posts = dbContext.Connection.Query<Post>("Post_package.getallPosts", commandType: CommandType.StoredProcedure);
            var postComentedOn = posts.Where(p => p.Postid == comment.Postid).SingleOrDefault();

            noti.Add("@UserIdd", postComentedOn.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CommentNotificationDTO> notificationcomments = dbContext.Connection.Query<CommentNotificationDTO>("Notifications_package_api.GetCommentNotificationByUserId", noti,
              commandType: CommandType.StoredProcedure);
            var commentedcom = notificationcomments.Where(c => c.CommentId == comm.Commentid).SingleOrDefault();

          
            var notification = new DynamicParameters();
            notification.Add("@Messagee",comment.Commenttext, dbType: DbType.String, direction: ParameterDirection.Input);

            notification.Add("@MessageIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            notification.Add("@IsRead", 0, dbType: DbType.Int32, direction: ParameterDirection.Input);


            notification.Add("@CommentIdd", comm.Commentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            notification.Add("@LikeIDD", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            notification.Add("@userFromm", comment.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            notification.Add("@userToo", postComentedOn.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            notification.Add("@ReportIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            notification.Add("@PostIdd", postComentedOn.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            notification.Add("@NotDate", now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            notification.Add("@FollowIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            notification.Add("@NType", commentedcom.UserFromImage, dbType: DbType.String, direction: ParameterDirection.Input);
            notification.Add("@NotificationTextt", commentedcom.UserFrom+" Commented On your post", dbType: DbType.String, direction: ParameterDirection.Input);

            var not = dbContext.Connection.Execute("Notifications_package_api.createNotfication", notification, commandType: CommandType.StoredProcedure);






     
            if (commentedcom != null)
            {
                commentedcom.NotificationText = "commented on your post";
                await hubContext.Clients.All.SendAsync("MessageReceived", commentedcom);

            }


        }



        public void UpdateComment(Postcomment Comment , int id )
        {
            var parameter = new DynamicParameters();
            parameter.Add("@commentIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@commentTextt", Comment.Commenttext, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@imagePathh", Comment.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Comment_package.UpdateComment", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
