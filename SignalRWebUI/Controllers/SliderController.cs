using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.SliderDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Controllers
{
    public class SliderController : Controller
    {
        private readonly ISliderApiService _SliderApiService;
        private readonly IMapper _mapper;

        public SliderController(ISliderApiService SliderApiService, IMapper mapper)
        {
            _SliderApiService = SliderApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> SliderList()
        {
            var values = await _SliderApiService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(SliderViewModel sliderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(sliderViewModel);
            }

            var createSliderDto = _mapper.Map<CreateSliderDto>(sliderViewModel);
            await _SliderApiService.CreateAsync(createSliderDto);
            return RedirectToAction("SliderList");
        }

        public async Task<IActionResult> DeleteSlider(int id)
        {
            await _SliderApiService.DeleteAsync(id);
            return RedirectToAction("SliderList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var value = await _SliderApiService.GetByIdAsync(id);
            var viewModel = _mapper.Map<SliderViewModel>(value);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(int id, SliderViewModel sliderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(sliderViewModel);
            }

            var dto = _mapper.Map<UpdateSliderDto>(sliderViewModel);
            await _SliderApiService.UpdateAsync(id, dto);
            return RedirectToAction("SliderList");
        }
    }
}