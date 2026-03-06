using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.SocialMediaDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

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
            var values = await _socialMediaApiService.GetAllAsync();
            var viewModels = _mapper.Map<List<SocialMediaViewModel>>(values);
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            if (!ModelState.IsValid)
                return View(createSocialMediaDto);

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
            var value = await _socialMediaApiService.GetByIdAsync(id);
            if (value is null) return NotFound();
            var dto = _mapper.Map<UpdateSocialMediaDto>(value);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(int id, UpdateSocialMediaDto updateSocialMediaDto)
        {
            if (!ModelState.IsValid)
                return View(updateSocialMediaDto);

            await _socialMediaApiService.UpdateAsync(id, updateSocialMediaDto);
            return RedirectToAction("SocialMediaList");
        }
    }
}