using System;
using System.Collections.Generic;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Userprofile
    {
        public Userprofile()
        {
            Activities = new HashSet<Activity>();
            Logins = new HashSet<Login>();
            MessageUserfromNavigations = new HashSet<Message>();
            MessageUsertoNavigations = new HashSet<Message>();
            Postcomments = new HashSet<Postcomment>();
            Postlikes = new HashSet<Postlike>();
            Posts = new HashSet<Post>();
            Purchases = new HashSet<Purchase>();
            ReportUserfromNavigations = new HashSet<Report>();
            ReportUsertoNavigations = new HashSet<Report>();
            Testimonials = new HashSet<Testimonial>();
        }

        public decimal Userid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Country { get; set; }
        public string Imagepath { get; set; }
        public bool? IsPremium { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Message> MessageUserfromNavigations { get; set; }
        public virtual ICollection<Message> MessageUsertoNavigations { get; set; }
        public virtual ICollection<Postcomment> Postcomments { get; set; }
        public virtual ICollection<Postlike> Postlikes { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Report> ReportUserfromNavigations { get; set; }
        public virtual ICollection<Report> ReportUsertoNavigations { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
