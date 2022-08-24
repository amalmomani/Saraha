using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.DTO
{
    public class UserMessage
    {
        public int FromId { get; set; }
        public string From { get; set; }
        public string UserFromImage { get; set; }
        public string To { get; set; }
        public int ToId { get; set; }
        public string MessageContent { get; set; }
        public bool Is_Anon { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
