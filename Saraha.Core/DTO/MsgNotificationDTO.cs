using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.DTO
{
 public   class MsgNotificationDTO
    {
        public string Title { set; get; }
        public string NotificationText { set; get; }
       public string UserTo { set; get; }
        public int UserToId { set; get; }
        public string UserToImage { set; get; }
        public int MessageId { set; get; }
        public string MessageText { set; get; }
        public DateTime MessageDate { set; get; }
        public string UserFrom { set; get; }
        public int userFromId { set; get; }
        public string UserFromImage { set; get; }





    }
}
