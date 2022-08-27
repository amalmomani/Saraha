using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.DTO
{
    public class PostLikesDTO
    {
        public string Auther { get; set; }
        public string LikeFrom { get; set; }
        public DateTime PostDate { get; set; }
        public string PostText { get; set; }
        public string PostImage { get; set; }
        public string UserLikeImage { get; set; }

    }
}
