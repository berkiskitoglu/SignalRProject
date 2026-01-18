using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediasController(ISocialMediaService SocialMediaService, IMapper mapper)
        {
            _socialMediaService = SocialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var socialMediaList = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(socialMediaList);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var socialMedia = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TAdd(socialMedia);
            return Ok("Sosyal Medya Bilgisi Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var itemToDelete = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(itemToDelete);
            return Ok("Sosyal Medya Bilgisi Silindi");
        }
        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var getSocialMediaById = _socialMediaService.TGetByID(id);
            return Ok(getSocialMediaById);
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var socialMedia = _socialMediaService.TGetByID(updateSocialMediaDto.SocialMediaID);
            if (socialMedia == null)
            {
                return NotFound("Sosyal Medya Bilgisi bulunamadı");
            }
            _mapper.Map(updateSocialMediaDto, socialMedia);
            _socialMediaService.TUpdate(socialMedia);
            return Ok("Sosyal Medya Bilgisi Güncellendi");
        }
    }
}
