using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Data
{
    public class Event
    {
        public int id { get; set; }
        public string type { get; set; }
        public string header { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public string text1 { get; set; }
        public string text2 { get; set; }
        public string text3 { get; set; }
        public string location { get; set; }
        public DateTime eventDate { get; set; }
    }
}
