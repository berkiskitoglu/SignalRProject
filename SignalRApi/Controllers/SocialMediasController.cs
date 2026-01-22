using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediasController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
            => Ok(_mapper.Map<List<ResultSocialMediaDto>>(await _socialMediaService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var socialMedia = _mapper.Map<SocialMedia>(createSocialMediaDto);
            await _socialMediaService.TAddAsync(socialMedia);
            return Ok("Sosyal Medya Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var itemToDelete = await _socialMediaService.TGetByIDAsync(id);
            if (itemToDelete == null)
                return NotFound("Sosyal Medya Bilgisi bulunamadı");
            await _socialMediaService.TDeleteAsync(itemToDelete);
            return Ok("Sosyal Medya Bilgisi Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var socialMedia = await _socialMediaService.TGetByIDAsync(id);
            if (socialMedia == null)
                return NotFound();
            var dto = _mapper.Map<ResultSocialMediaDto>(socialMedia);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSocialMedia(int id, UpdateSocialMediaDto updateSocialMediaDto)
        {
            var socialMedia = await _socialMediaService.TGetByIDAsync(id);
            if (socialMedia == null)
                return NotFound("Sosyal Medya Bilgisi bulunamadı");
            _mapper.Map(updateSocialMediaDto, socialMedia);
            await _socialMediaService.TUpdateAsync(socialMedia);
            return Ok("Sosyal Medya Bilgisi Güncellendi");
        }
    }
}