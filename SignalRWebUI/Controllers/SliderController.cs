using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.SliderDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Controllers
{
    public class SliderController : Controller
    {
        private readonly ISliderApiService _sliderApiService;
        private readonly IMapper _mapper;

        public SliderController(ISliderApiService sliderApiService, IMapper mapper)
        {
            _sliderApiService = sliderApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> SliderList()
        {
            var values = await _sliderApiService.GetAllAsync();
            var viewModels = _mapper.Map<List<SliderViewModel>>(values);
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            if (!ModelState.IsValid)
                return View(createSliderDto);

            await _sliderApiService.CreateAsync(createSliderDto);
            return RedirectToAction("SliderList");
        }

        public async Task<IActionResult> DeleteSlider(int id)
        {
            await _sliderApiService.DeleteAsync(id);
            return RedirectToAction("SliderList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var value = await _sliderApiService.GetByIdAsync(id);
            if (value is null) return NotFound();
            var dto = _mapper.Map<UpdateSliderDto>(value);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(int id, UpdateSliderDto updateSliderDto)
        {
            if (!ModelState.IsValid)
                return View(updateSliderDto);

            await _sliderApiService.UpdateAsync(id, updateSliderDto);
            return RedirectToAction("SliderList");
        }
    }
}