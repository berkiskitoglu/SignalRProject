using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.AboutDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels.AboutViewModels;

namespace SignalRWebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutApiService _aboutApiService;
        private readonly IMapper _mapper;

        public AboutController(IAboutApiService aboutApiService, IMapper mapper)
        {
            _aboutApiService = aboutApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> AboutList()
        {
            List<ResultAboutDto> values = await _aboutApiService.GetAllAsync();
            List<ResultAboutViewModel> resultAboutViewModels = _mapper.Map<List<ResultAboutViewModel>>(values);
            return View(resultAboutViewModels);
        }

        [HttpGet]
        public IActionResult CreateAbout() => View();

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutViewModel createAboutViewModel)
        {
            if (!ModelState.IsValid)
                return View(createAboutViewModel);

            CreateAboutDto createAboutDto = _mapper.Map<CreateAboutDto>(createAboutViewModel);
            await _aboutApiService.CreateAsync(createAboutDto);
            return RedirectToAction("AboutList");
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _aboutApiService.DeleteAsync(id);
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            GetAboutDto getAboutDto = await _aboutApiService.GetByIdAsync(id);
            if (getAboutDto is null) return NotFound();
            UpdateAboutViewModel updateAboutViewModel = _mapper.Map<UpdateAboutViewModel>(getAboutDto);
            return View(updateAboutViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(int id, UpdateAboutViewModel updateAboutViewModel)
        {
            if (!ModelState.IsValid)
                return View(updateAboutViewModel);

            UpdateAboutDto updateAboutDto = _mapper.Map<UpdateAboutDto>(updateAboutViewModel);
            await _aboutApiService.UpdateAsync(id, updateAboutDto);
            return RedirectToAction("AboutList");
        }
    }
}