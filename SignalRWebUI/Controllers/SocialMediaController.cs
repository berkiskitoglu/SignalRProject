using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.SocialMediaDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaApiService _SocialMediaApiService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaApiService SocialMediaApiService, IMapper mapper)
        {
            _SocialMediaApiService = SocialMediaApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> SocialMediaList()
        {
            var values = await _SocialMediaApiService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(SocialMediaViewModel socialMediaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(socialMediaViewModel);
            }

            var createSocialMediaDto = _mapper.Map<CreateSocialMediaDto>(socialMediaViewModel);
            await _SocialMediaApiService.CreateAsync(createSocialMediaDto);
            return RedirectToAction("SocialMediaList");
        }

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _SocialMediaApiService.DeleteAsync(id);
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var value = await _SocialMediaApiService.GetByIdAsync(id);
            var viewModel = _mapper.Map<SocialMediaViewModel>(value);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(int id, SocialMediaViewModel socialMediaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(socialMediaViewModel);
            }

            var dto = _mapper.Map<UpdateSocialMediaDto>(socialMediaViewModel);
            await _SocialMediaApiService.UpdateAsync(id, dto);
            return RedirectToAction("SocialMediaList");
        }
    }
}