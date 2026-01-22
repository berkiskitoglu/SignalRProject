using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialsController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
            => Ok(_mapper.Map<List<ResultTestimonialDto>>(await _testimonialService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            await _testimonialService.TAddAsync(testimonial);
            return Ok("Referans Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var itemToDelete = await _testimonialService.TGetByIDAsync(id);
            if (itemToDelete == null)
                return NotFound("Referans bulunamadı");
            await _testimonialService.TDeleteAsync(itemToDelete);
            return Ok("Referans Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var testimonial = await _testimonialService.TGetByIDAsync(id);
            if (testimonial == null)
                return NotFound();
            var dto = _mapper.Map<ResultTestimonialDto>(testimonial);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTestimonial(int id, UpdateTestimonialDto updateTestimonialDto)
        {
            var testimonial = await _testimonialService.TGetByIDAsync(id);
            if (testimonial == null)
                return NotFound("Referans bulunamadı");
            _mapper.Map(updateTestimonialDto, testimonial);
            await _testimonialService.TUpdateAsync(testimonial);
            return Ok("Referans Güncellendi");
        }
    }
}