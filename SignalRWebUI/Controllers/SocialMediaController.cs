using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.SocialMediaDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels.SocialMediaViewModels;

namespace SignalRWebUI.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaApiService _socialMediaApiService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaApiService socialMediaApiService, IMapper mapper)
        {
            _socialMediaApiService = socialMediaApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> SocialMediaList()
        {
            List<ResultSocialMediaDto> values = await _socialMediaApiService.GetAllAsync();
            List<ResultSocialMediaViewModel> resultSocialMediaViewModels = _mapper.Map<List<ResultSocialMediaViewModel>>(values);
            return View(resultSocialMediaViewModels);
        }

        [HttpGet]
        public IActionResult CreateSocialMedia() => View();

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaViewModel createSocialMediaViewModel)
        {
            if (!ModelState.IsValid)
                return View(createSocialMediaViewModel);

            CreateSocialMediaDto createSocialMediaDto = _mapper.Map<CreateSocialMediaDto>(createSocialMediaViewModel);
            await _socialMediaApiService.CreateAsync(createSocialMediaDto);
            return RedirectToAction("SocialMediaList");
        }

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _socialMediaApiService.DeleteAsync(id);
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            GetSocialMediaDto getSocialMediaDto = await _socialMediaApiService.GetByIdAsync(id);
            if (getSocialMediaDto is null) return NotFound();
            UpdateSocialMediaViewModel updateSocialMediaViewModel = _mapper.Map<UpdateSocialMediaViewModel>(getSocialMediaDto);
            return View(updateSocialMediaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(int id, UpdateSocialMediaViewModel updateSocialMediaViewModel)
        {
            if (!ModelState.IsValid)
                return View(updateSocialMediaViewModel);

            UpdateSocialMediaDto updateSocialMediaDto = _mapper.Map<UpdateSocialMediaDto>(updateSocialMediaViewModel);
            await _socialMediaApiService.UpdateAsync(id, updateSocialMediaDto);
            return RedirectToAction("SocialMediaList");
        }
    }
}