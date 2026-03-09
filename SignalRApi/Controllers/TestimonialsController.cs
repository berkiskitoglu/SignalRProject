using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTestimonialDto> _createValidator;
        private readonly IValidator<UpdateTestimonialDto> _updateValidator;

        public TestimonialsController(
            ITestimonialService testimonialService,
            IMapper mapper,
            IValidator<CreateTestimonialDto> createValidator,
            IValidator<UpdateTestimonialDto> updateValidator)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
            => Ok(_mapper.Map<List<ResultTestimonialDto>>(await _testimonialService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var validationResult = await _createValidator.ValidateAsync(createTestimonialDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            await _testimonialService.TAddAsync(_mapper.Map<Testimonial>(createTestimonialDto));
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
                return NotFound("Referans bulunamadı");

            return Ok(_mapper.Map<ResultTestimonialDto>(testimonial));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTestimonial(int id, UpdateTestimonialDto updateTestimonialDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateTestimonialDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            var testimonial = await _testimonialService.TGetByIDAsync(id);
            if (testimonial == null)
                return NotFound("Referans bulunamadı");

            _mapper.Map(updateTestimonialDto, testimonial);
            await _testimonialService.TUpdateAsync(testimonial);
            return Ok("Referans Güncellendi");
        }
    }
}