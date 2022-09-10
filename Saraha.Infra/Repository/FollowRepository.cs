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
    public class FollowRepository : IFollowRepository
    {
        private readonly IDbcontext dbContext;
        private readonly IHubContext<MessageHub> hubContext;



        public FollowRepository(IDbcontext dbContext, IHubContext<MessageHub> hubContext)
        {
            this.dbContext = dbContext;
            this.hubContext = hubContext;
        }
        public async void CreateFollow(Follow follow)
        {
            DateTime now = DateTime.Now;
            var parameter = new DynamicParameters();
            IEnumerable<Follow> allFollows = dbContext.Connection.Query<Follow>("Follow_Package.GetAll", commandType: CommandType.StoredProcedure);
            var fDone = allFollows.Where(f => f.UserFrom == follow.UserFrom && f.UserTo == f.UserTo && f.FollowDate.ToString() == now.ToString()).SingleOrDefault();


            //var exist = allFollows.Any(f => f.UserFrom == follow.UserFrom && f.UserTo == follow.UserTo);
            //if (!exist)
            //{

                parameter.Add("@UserFromm", follow.UserFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("@UserToo", follow.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("@FollowDatee", now, dbType: DbType.DateTime, direction: ParameterDirection.Input);

                var result = dbContext.Connection.Execute("Follow_Package.CreateFollow", parameter, commandType: CommandType.StoredProcedure);


                IEnumerable<Follow> follows = dbContext.Connection.Query<Follow>("Follow_Package.GetAll", commandType: CommandType.StoredProcedure);
                var folllowDone = follows.Where(f => f.UserFrom == follow.UserFrom && f.UserTo == f.UserTo && f.FollowDate.ToString() == now.ToString()).SingleOrDefault();
                var pa = new DynamicParameters();
                pa.Add("@UserIDD", follow.UserFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
                pa.Add("@LikeIDD", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
                pa.Add("@CommentIDD", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
                pa.Add("@PostIDD", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
                pa.Add("@ActivityNamee", "follow", dbType: DbType.String, direction: ParameterDirection.Input);
                pa.Add("@Messagee", "Following", dbType: DbType.String, direction: ParameterDirection.Input);
                pa.Add("@ActivityDatee", DateTime.Now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                pa.Add("@FollowIdd", folllowDone.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var r = dbContext.Connection.Execute("Activity_package_api.createActivity", pa, commandType: CommandType.StoredProcedure);


                var noti = new DynamicParameters();

                noti.Add("@UserIdd", follow.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);
                IEnumerable<FollowNotificationDTO> fls = dbContext.Connection.Query<FollowNotificationDTO>("Notifications_package_api.GetFollowNotificationByUserId", noti,
                  commandType: CommandType.StoredProcedure);
                var followw = fls.Where(f => f.FollowId == folllowDone.Id).SingleOrDefault();

                //Add commment to notifications 

                var notification = new DynamicParameters();
                notification.Add("@Messagee", followw.UserFromImage, dbType: DbType.String, direction: ParameterDirection.Input);

                notification.Add("@MessageIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
                notification.Add("@IsRead", 0, dbType: DbType.Int32, direction: ParameterDirection.Input);


                notification.Add("@CommentIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
                notification.Add("@LikeIDD", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
                notification.Add("@userFromm", follow.UserFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
                notification.Add("@userToo", follow.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);
                notification.Add("@ReportIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
                notification.Add("@PostIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);

                notification.Add("@NotDate", now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                notification.Add("@FollowIdd", folllowDone.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                notification.Add("@Ntype", "follow", dbType: DbType.String, direction: ParameterDirection.Input);
                notification.Add("@NotificationTextt", followw.UserFrom+" Started Following You", dbType: DbType.String, direction: ParameterDirection.Input);

                var not = dbContext.Connection.Execute("Notifications_package_api.createNotfication", notification, commandType: CommandType.StoredProcedure);






                if (followw != null)
                {
                    followw.NotificationText = "started Following you";
                    await hubContext.Clients.All.SendAsync("MessageReceived", followw);
                    var paramete = new DynamicParameters();
                    paramete.Add("@UserIdd", follow.UserFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    IEnumerable<Notifications> nots = dbContext.Connection.Query<Notifications>("Notifications_package_api.GetNotificationByUserId", paramete, commandType: CommandType.StoredProcedure);
                    await hubContext.Clients.All.SendAsync("NotificationReceived", nots);
                    var notsCount = nots.Where(x => x.Is_Read == 0).ToList().Count();
                    await hubContext.Clients.All.SendAsync("NotCount", notsCount);
                }
 



        }

        public void DeleteFollow(int id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Idd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
         
            var result = dbContext.Connection.Execute("Follow_Package.DeleteFollow", parameter, commandType: CommandType.StoredProcedure);
        }

        public void DeleteFollowByUser(int userFrom, int userTo)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@UserFromm", userFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@UserToo", userTo, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Follow_Package.DeleteFollowByUser",
                parameter, commandType: CommandType.StoredProcedure);
        }

        public List<Follow> GetAll()
        {
           
            IEnumerable<Follow> result = dbContext.Connection.Query<Follow>("Follow_Package.GetAll", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<Userprofile> GetFollowers(int userTo)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@UserToo", userTo, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Userprofile> result = dbContext.Connection.Query<Userprofile>("Follow_Package.GetFollowers",
                parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<Userprofile> GetFollowing(int userFrom)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@UserFromm", userFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Userprofile> result = dbContext.Connection.Query<Userprofile>("Follow_Package.GetFollowing",
                parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool IsBlock(int userFrom, int userTo)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@UserFromm", userFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@UserToo", userTo, dbType: DbType.Int32, direction: ParameterDirection.Input);

            int result = dbContext.Connection.QuerySingleOrDefault<int>("Follow_Package.IsBlock",
                parameter, commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public bool IsFollow(int userFrom, int userTo)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@UserFromm", userFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@UserToo", userTo, dbType: DbType.Int32, direction: ParameterDirection.Input);

            int result = dbContext.Connection.QuerySingleOrDefault<int>("Follow_Package.IsFollow", 
                parameter, commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public void UpdateBlockStatus(int id, int isBlock)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Idd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@IsBlockk", isBlock, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("Follow_Package.UpdateBlockStatus", parameter, commandType: CommandType.StoredProcedure);
        }

        public void UpdateBlockUser(int userFrom, int userTo, int isBlock)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@UserFromm", userFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@UserToo", userTo, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@IsBlockk", isBlock, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("Follow_Package.UpdateBlockUser", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
