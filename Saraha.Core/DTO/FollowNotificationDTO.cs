using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.DTO
{
  public  class FollowNotificationDTO
    {
        public string Title { set; get; }
        public string NotificationText { set; get; }
        public string UserTo { set; get; }
        public int UserToId { set; get; }
        public string UserToImage { set; get; }
        public DateTime FollowDate { set; get; }
        public int FollowId { set; get; }
        public string UserFrom { set; get; }
        public int UserFromId { set; get; }
        public string UserFromImage { set; get; }






    }
}
