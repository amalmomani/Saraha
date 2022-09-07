using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Data
{
   public class Notifications
    {
        public string Message { set; get; }
        public int MessageId { set; get; }
        public int Is_Read { set; get; }
        public int CommentId { set; get; }
        public int LikeId { set; get; }
        public int UserFrom { set; get; }
        public int UseTo { set; get; } 
        public int ReportId { set; get; }
        public int PostId { set; get; }
        public DateTime NotificationDate { set; get; }
        public int FollowId { set; get; }
        public string NotType { set; get; }
     }
}
