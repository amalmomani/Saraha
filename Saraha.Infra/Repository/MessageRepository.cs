using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.AspNetCore.SignalR;
using Saraha.Core.Common;
using Saraha.Core.Data;
using Saraha.Core.DTO;
using Saraha.Core.Repository;

namespace Saraha.Infra.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IDbcontext dbContext;
        private readonly IHubContext<MessageHub> hubContext;


        public MessageRepository(IDbcontext dbContext, IHubContext<MessageHub> hubContext)
        {
            this.dbContext = dbContext;
            this.hubContext = hubContext;
        }
       

        public async void CreateMessage(Message message, int userLoggedId)
        {
            DateTime now = DateTime.Now;
            var parameter = new DynamicParameters();

            parameter.Add("@MessageContentt", message.MessageContent, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Is_Anonn", message.Is_Anon, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@MessageDatee", now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@UserFromm", message.UserFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@UserToo", message.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Message_package_api.createMessage", parameter, commandType: CommandType.StoredProcedure);

            //Add message to notifications 
            var noti = new DynamicParameters();
            IEnumerable<Message> messages = dbContext.Connection.Query<Message>("Message_package_api.getallMessage", commandType: CommandType.StoredProcedure);
            var msg = messages.Where(m => m.MessageContent == message.MessageContent && m.UserFrom == message.UserFrom && m.MessageDate.ToString() == now.ToString()).SingleOrDefault();


            noti.Add("@UserIdd", msg.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<MsgNotificationDTO> notificationMsgs = dbContext.Connection.Query<MsgNotificationDTO>("Notifications_package_api.GetMessageNotificationByUserId", noti,
              commandType: CommandType.StoredProcedure);
            var msgNoti = notificationMsgs.Where(m => m.MessageId == msg.MessageID).SingleOrDefault();

      

            var notification = new DynamicParameters();
            notification.Add("@Messagee",message.MessageContent, dbType: DbType.String, direction: ParameterDirection.Input);

            notification.Add("@MessageIdd", msg.MessageID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            notification.Add("@IsRead", 0, dbType: DbType.Int32, direction: ParameterDirection.Input);


            notification.Add("@CommentIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            notification.Add("@LikeIDD",null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            notification.Add("@userFromm",msg.UserFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            notification.Add("@userToo", msg.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);
            notification.Add("@ReportIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            notification.Add("@PostIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);

            notification.Add("@NotDate", now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            notification.Add("@FollowIdd", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            notification.Add("@NType", msgNoti.UserFromImage, dbType: DbType.String, direction: ParameterDirection.Input);
            notification.Add("@NotificationTextt", msgNoti.UserFrom + " Sent you message", dbType: DbType.String, direction: ParameterDirection.Input);

            var not = dbContext.Connection.Execute("Notifications_package_api.createNotfication", notification, commandType: CommandType.StoredProcedure);


       
            if (msgNoti != null)
            {
                msgNoti.NotificationText = "sent you message";
                msgNoti.Title = "New Message";
                await this.hubContext.Clients.All.SendAsync("MessageReceived", msgNoti);

            }



        }



        public void DeleteMessage(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@MessageIDD", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Message_package_api.deleteMessage", parameter, commandType: CommandType.StoredProcedure);

        }

       

        public List<Message> GetallMessage()
        {
            IEnumerable<Message> result = dbContext.Connection.Query<Message>("Message_package_api.getallMessage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void UpdateMessage(Message message)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@MessageIDD", message.MessageID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@MessageContentt", message.MessageContent, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Is_Anonn", message.Is_Anon, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@MessageDatee", message.MessageDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@UserFromm", message.UserFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@UserToo", message.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Message_package_api.UpdateMessage", parameter, commandType: CommandType.StoredProcedure);
      
        }

        public List<UserMessage> GetUserMessage()
        {
            IEnumerable<UserMessage> result = dbContext.Connection.Query<UserMessage>("DTOPackage.UserMessage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<UserMessage> GetUserMessageById(int userId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@userIdd", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<UserMessage> result = dbContext.Connection.Query<UserMessage>("GetUserMessageById",parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Message> GetUserMessageByIdcount(int userId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@userIdd", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Message> result = dbContext.Connection.Query<Message>("GetUserMessageByIdcount", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }
}
