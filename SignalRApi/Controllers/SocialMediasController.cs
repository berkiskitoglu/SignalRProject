using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateSocialMediaDto> _createValidator;
        private readonly IValidator<UpdateSocialMediaDto> _updateValidator;

        public SocialMediasController(
            ISocialMediaService socialMediaService,
            IMapper mapper,
            IValidator<CreateSocialMediaDto> createValidator,
            IValidator<UpdateSocialMediaDto> updateValidator)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
            => Ok(_mapper.Map<List<ResultSocialMediaDto>>(await _socialMediaService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var validationResult = await _createValidator.ValidateAsync(createSocialMediaDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            await _socialMediaService.TAddAsync(_mapper.Map<SocialMedia>(createSocialMediaDto));
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
                return NotFound("Sosyal Medya Bilgisi bulunamadı");

            return Ok(_mapper.Map<ResultSocialMediaDto>(socialMedia));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSocialMedia(int id, UpdateSocialMediaDto updateSocialMediaDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateSocialMediaDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            var socialMedia = await _socialMediaService.TGetByIDAsync(id);
            if (socialMedia == null)
                return NotFound("Sosyal Medya Bilgisi bulunamadı");

            _mapper.Map(updateSocialMediaDto, socialMedia);
            await _socialMediaService.TUpdateAsync(socialMedia);
            return Ok("Sosyal Medya Bilgisi Güncellendi");
        }
    }
}