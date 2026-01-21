using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.TestimonialDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialApiService _TestimonialApiService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialApiService TestimonialApiService, IMapper mapper)
        {
            _TestimonialApiService = TestimonialApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> TestimonialList()
        {
            var values = await _TestimonialApiService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(TestimonialViewModel TestimonialViewModel)
        {

            var createTestimonialDto = _mapper.Map<CreateTestimonialDto>(TestimonialViewModel);
            await _TestimonialApiService.CreateAsync(createTestimonialDto);
            return RedirectToAction("TestimonialList");
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {

            await _TestimonialApiService.DeleteAsync(id);
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var value = await _TestimonialApiService.GetByIdAsync(id);
            var viewModel = _mapper.Map<TestimonialViewModel>(value);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(int id, TestimonialViewModel TestimonialViewModel)
        {

            var dto = _mapper.Map<UpdateTestimonialDto>(TestimonialViewModel);
            await _TestimonialApiService.UpdateAsync(id, dto);
            return RedirectToAction("TestimonialList");
        }
    }
}
