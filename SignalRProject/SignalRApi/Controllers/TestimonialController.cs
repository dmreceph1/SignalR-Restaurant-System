using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Businesslayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createDto)
        {
            Testimonial testimonial = new Testimonial()
            {
                Name = createDto.Name,
                Title = createDto.Title,
                Comment = createDto.Comment,
                ImageUrl = createDto.ImageUrl,
                Status = createDto.Status
            };
            _testimonialService.TAdd(testimonial);
            return Ok("Testimonial başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(value);
            return Ok("Testimonial silindi");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateDto)
        {
            Testimonial testimonial = new Testimonial()
            {
                TestimonialID = updateDto.TestimonialID,
                Name = updateDto.Name,
                Title = updateDto.Title,
                Comment = updateDto.Comment,
                ImageUrl = updateDto.ImageUrl,
                Status = updateDto.Status
            };
            _testimonialService.TUpdate(testimonial);
            return Ok("Testimonial güncellendi");
        }
    }
}
