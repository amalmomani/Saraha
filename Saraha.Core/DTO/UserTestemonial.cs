using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.DTO
{
    public class UserTestemonial
    {
        public string User { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public int Stars { get; set; }
        public int Testimonialid { get; set; }
        public bool is_accepted { get; set; }
    }
}
