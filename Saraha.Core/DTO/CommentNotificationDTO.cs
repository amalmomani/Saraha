using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.DTO
{
  public class CommentNotificationDTO
    {
        public string Title { set; get; }
        public string NotificationText { set; get; }
        public string UserTo { set; get; }
        public int UserToId { set; get; }
        public string UserToImage { set; get; }
        public int PostId { set; get; }
        public string PostText { set; get; }
        public DateTime CommentDate { set; get;  }
        public int CommentId { set; get; }
        public string CommentText { set; get; }
        public string UserFrom { set; get; }
        public int UserFromId { set; get; }
        public string UserFromImage { set; get; }







    }
}
