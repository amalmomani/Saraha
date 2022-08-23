using Saraha.Core.Data;
using Saraha.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Service
{
     public interface ITestimonialService
    {
        public bool CreateTestimonial(Testimonial testimonial);
        public bool UpdateTestimonial(Testimonial testimonial);
        public List<Testimonial> GetAllTestimonials();
        public bool DeleteTestimonial(int id);
        public bool UpdateAcceptingStatus(int isAccepted, int testimonialId);
        public Testimonial GetTestimonialByUserId(int UserId);
        public List<UserTestemonial> GetUserTestemonial();

    }
}

