using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Saraha.Core.Data
{
    public class Follow
    {
        [Key]
        public int Id { get; set; }
        public int UserFrom { get; set; }
        public int UserTo { get; set; }
        public DateTime? FollowDate { get; set; }
        public bool IsBlock { get; set; }
    }
}
