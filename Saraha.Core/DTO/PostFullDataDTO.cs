using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.DTO
{
  public class PostFullDataDTO
    {

        public string Auther { set; get; }
        public string AutherImage { set; get; }
        public DateTime PostDate { set; get; }
        public string PostText { set; get; }
        public string PostImage { set; get; }
        public string PostType  { set; get; }
        public int PostId { set; get; }

        public string Likes { set; get; }
        public string Comments { set; get; }
        public bool? Is_Pin { get; set; }






    }
}
