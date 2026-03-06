using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.AboutDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

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
            var values = await _aboutApiService.GetAllAsync();
            var viewModels = _mapper.Map<List<AboutViewModel>>(values);
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(AboutViewModel aboutViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(aboutViewModel);
            }

            var createAboutDto = _mapper.Map<CreateAboutDto>(aboutViewModel);
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
            var value = await _aboutApiService.GetByIdAsync(id);
            if (value is null) return NotFound();
            var  updateAboutDto = _mapper.Map<UpdateAboutDto>(value);
            return View(updateAboutDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(int id, UpdateAboutDto updateAboutDto)
        {
            if (!ModelState.IsValid)
                return View(updateAboutDto);

            await _aboutApiService.UpdateAsync(id, updateAboutDto);
            return RedirectToAction("AboutList");
        }
    }
}