using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.SliderDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels.SliderViewModels;

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
            List<ResultSliderDto> values = await _sliderApiService.GetAllAsync();
            List<ResultSliderViewModel> resultSliderViewModels = _mapper.Map<List<ResultSliderViewModel>>(values);
            return View(resultSliderViewModels);
        }

        [HttpGet]
        public IActionResult CreateSlider() => View();

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderViewModel createSliderViewModel)
        {
            if (!ModelState.IsValid)
                return View(createSliderViewModel);

            CreateSliderDto createSliderDto = _mapper.Map<CreateSliderDto>(createSliderViewModel);
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
            GetSliderDto getSliderDto = await _sliderApiService.GetByIdAsync(id);
            if (getSliderDto is null) return NotFound();
            UpdateSliderViewModel updateSliderViewModel = _mapper.Map<UpdateSliderViewModel>(getSliderDto);
            return View(updateSliderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(int id, UpdateSliderViewModel updateSliderViewModel)
        {
            if (!ModelState.IsValid)
                return View(updateSliderViewModel);

            UpdateSliderDto updateSliderDto = _mapper.Map<UpdateSliderDto>(updateSliderViewModel);
            await _sliderApiService.UpdateAsync(id, updateSliderDto);
            return RedirectToAction("SliderList");
        }
    }
}