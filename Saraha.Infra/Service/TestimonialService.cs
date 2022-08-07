using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository testimonialRepository;
        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            this.testimonialRepository = testimonialRepository;
        }
        public bool CreateTestimonial(Testimonial testimonial)
        {
            return testimonialRepository.CreateTestimonial(testimonial);
        }

        public bool DeleteTestimonial(int id)
        {
            return testimonialRepository.DeleteTestimonial(id);
        }

        public List<Testimonial> GetAllTestimonials()
        {
            return testimonialRepository.GetAllTestimonials();
        }

        public Testimonial GetTestimonialByUserId(int UserId)
        {
            return testimonialRepository.GetTestimonialByUserId(UserId);
        }

        public bool UpdateAcceptingStatus(int isAccepted, int testimonialId)
        {
            return testimonialRepository.UpdateAcceptingStatus(isAccepted,testimonialId);
        }

        public bool UpdateTestimonial(Testimonial testimonial)
        {
            return testimonialRepository.UpdateTestimonial(testimonial);
        }
    }
}
