using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.DTO
{
    public class UserMessage
    {
        public string MessageId { get; set; }
        public string From { get; set; }
        public string UserFromImage { get; set; }
        public string To { get; set; }
        public string MessageContent { get; set; }
        public string Status { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
