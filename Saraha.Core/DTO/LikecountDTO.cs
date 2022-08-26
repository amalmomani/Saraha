using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.DTO
{
    class LikecountDTO
    {
        public string Auther { get; set; }
        public string LikeFrom { get; set; }
        public DateTime PostDate { get; set; }
        public string PostText { get; set; }
        public string PostImage { get; set; }
    }
}
