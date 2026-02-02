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
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(AboutViewModel AboutViewModel)
        {

            var createAboutDto = _mapper.Map<CreateAboutDto>(AboutViewModel);
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
            var viewModel = _mapper.Map<AboutViewModel>(value);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(int id, AboutViewModel AboutViewModel)
        {

            var dto = _mapper.Map<UpdateAboutDto>(AboutViewModel);
            await _aboutApiService.UpdateAsync(id, dto);
            return RedirectToAction("AboutList");
        }

    }
}
