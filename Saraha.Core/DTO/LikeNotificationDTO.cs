using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.DTO
{
    public class LikeNotificationDTO
    {
        public string UserTo { set; get; }
        public int UserToId { set; get; }


        public string UserToImage { set; get; }
        public int PostId { set; get; }

        public string PostText { set; get; }
        public DateTime LikeDate { set; get; }
        public int LikeId { set; get; }
        public string UserFrom { set; get; }
        public int UserFromId { set; get; }
        public string userFromImage { set; get; }
        public string NotificationText { set; get; }



    }
}
