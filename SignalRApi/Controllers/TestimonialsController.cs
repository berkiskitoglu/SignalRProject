using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialsController(ITestimonialService TestimonialService, IMapper mapper)
        {
            _testimonialService = TestimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var testimonialList = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(testimonialList);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(testimonial);
            return Ok("Referans Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var itemToDelete = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(itemToDelete);
            return Ok("Referans Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var testimonial = _testimonialService.TGetByID(id);
            if (testimonial == null)
                return NotFound();

            var dto = _mapper.Map<ResultTestimonialDto>(testimonial);
            return Ok(dto);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTestimonial(int id , UpdateTestimonialDto updateTestimonialDto)
        {
            var testimonial = _testimonialService.TGetByID(id);
            if (testimonial == null)
            {
                return NotFound("Referans bulunamadı");
            }
            _mapper.Map(updateTestimonialDto, testimonial);
            _testimonialService.TUpdate(testimonial);
            return Ok("Referans Güncellendi");
        }
    }
}
