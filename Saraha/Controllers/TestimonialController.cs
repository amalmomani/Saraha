using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saraha.Core.Data;
using Saraha.Core.DTO;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saraha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            this.testimonialService = testimonialService;
        }

        [HttpPost]
        public bool CreateTestimonial([FromBody] Testimonial testimonial)
        {
            return testimonialService.CreateTestimonial(testimonial);
        }
        
        [HttpPut]
        public bool UpdateTestimonial(Testimonial testimonial)
        {
            return testimonialService.UpdateTestimonial(testimonial);
        }

        [HttpGet]
        public List<Testimonial> GetAllTestimonials()
        {
            return testimonialService.GetAllTestimonials();
        }

        [HttpDelete]
        [Route("{id}")]
        public bool DeleteTestimonial(int id)
        {
            return testimonialService.DeleteTestimonial(id);
        }

        [HttpGet]
        [Route("UpdateAcceptingStatus/{isAccepted}/{testimonialId}")]
        public bool UpdateAcceptingStatus(int isAccepted, int testimonialId)
        {
            return testimonialService.UpdateAcceptingStatus(isAccepted, testimonialId);
        }

        [HttpGet]
        [Route("GetTestimonialByUserId/{UserId}")]
        public Testimonial GetTestimonialByUserId(int UserId)
        {
            return testimonialService.GetTestimonialByUserId(UserId);
        }
        [HttpGet]
        [Route("GetUserTestemonial")]
        public List<UserTestemonial> GetUserTestemonials()
        {
            return testimonialService.GetUserTestemonial();
        }
    }
}
