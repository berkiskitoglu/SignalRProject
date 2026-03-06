using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.TestimonialDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialApiService _testimonialApiService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialApiService testimonialApiService, IMapper mapper)
        {
            _testimonialApiService = testimonialApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> TestimonialList()
        {
            var values = await _testimonialApiService.GetAllAsync();
            var viewModels = _mapper.Map<List<TestimonialViewModel>>(values);
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            if (!ModelState.IsValid)
                return View(createTestimonialDto);

            await _testimonialApiService.CreateAsync(createTestimonialDto);
            return RedirectToAction("TestimonialList");
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialApiService.DeleteAsync(id);
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var value = await _testimonialApiService.GetByIdAsync(id);
            if (value is null) return NotFound();
            var dto = _mapper.Map<UpdateTestimonialDto>(value);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(int id, UpdateTestimonialDto updateTestimonialDto)
        {
            if (!ModelState.IsValid)
                return View(updateTestimonialDto);

            await _testimonialApiService.UpdateAsync(id, updateTestimonialDto);
            return RedirectToAction("TestimonialList");
        }
    }
}