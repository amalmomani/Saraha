using Saraha.Core.Common;
using Saraha.Core.Data;
using Saraha.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Repository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDbcontext dbContext;

        public TestimonialRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool CreateTestimonial(Testimonial testimonial)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTestimonial(int id)
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> GetAllTestimonials()
        {
            throw new NotImplementedException();
        }

        public Testimonial GetTestimonialByUserId(int UserId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAcceptingStatus(int isAccepted, int testimonialId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTestimonial(Testimonial testimonial)
        {
            throw new NotImplementedException();
        }
    }
}
