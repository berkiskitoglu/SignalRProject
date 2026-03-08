using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.TestimonialDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels.TestimonialViewModels;

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
            List<ResultTestimonialDto> values = await _testimonialApiService.GetAllAsync();
            List<ResultTestimonialViewModel> resultTestimonialViewModels = _mapper.Map<List<ResultTestimonialViewModel>>(values);
            return View(resultTestimonialViewModels);
        }

        [HttpGet]
        public IActionResult CreateTestimonial() => View();

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialViewModel createTestimonialViewModel)
        {
            if (!ModelState.IsValid)
                return View(createTestimonialViewModel);

            CreateTestimonialDto createTestimonialDto = _mapper.Map<CreateTestimonialDto>(createTestimonialViewModel);
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
            GetTestimonialDto getTestimonialDto = await _testimonialApiService.GetByIdAsync(id);
            if (getTestimonialDto is null) return NotFound();
            UpdateTestimonialViewModel updateTestimonialViewModel = _mapper.Map<UpdateTestimonialViewModel>(getTestimonialDto);
            return View(updateTestimonialViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(int id, UpdateTestimonialViewModel updateTestimonialViewModel)
        {
            if (!ModelState.IsValid)
                return View(updateTestimonialViewModel);

            UpdateTestimonialDto updateTestimonialDto = _mapper.Map<UpdateTestimonialDto>(updateTestimonialViewModel);
            await _testimonialApiService.UpdateAsync(id, updateTestimonialDto);
            return RedirectToAction("TestimonialList");
        }
    }
}