using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateAboutDto> _createValidator;
        private readonly IValidator<UpdateAboutDto> _updateValidator;

        public AboutsController(
            IAboutService aboutService,
            IMapper mapper,
            IValidator<CreateAboutDto> createValidator,
            IValidator<UpdateAboutDto> updateValidator)
        {
            _aboutService = aboutService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
            => Ok(_mapper.Map<List<ResultAboutDto>>(await _aboutService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            var validationResult = await _createValidator.ValidateAsync(createAboutDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            await _aboutService.TAddAsync(_mapper.Map<About>(createAboutDto));
            return Ok("Hakkımda Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var itemToDelete = await _aboutService.TGetByIDAsync(id);
            if (itemToDelete == null)
                return NotFound("Hakkımda bilgisi bulunamadı");

            await _aboutService.TDeleteAsync(itemToDelete);
            return Ok("Hakkımda Bilgisi Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var about = await _aboutService.TGetByIDAsync(id);
            if (about == null)
                return NotFound("Hakkımda bilgisi bulunamadı");

            return Ok(_mapper.Map<ResultAboutDto>(about));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAbout(int id, UpdateAboutDto updateAboutDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateAboutDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            var about = await _aboutService.TGetByIDAsync(id);
            if (about == null)
                return NotFound("Hakkımda bilgisi bulunamadı");

            _mapper.Map(updateAboutDto, about);
            await _aboutService.TUpdateAsync(about);
            return Ok("Hakkımda Bilgisi Güncellendi");
        }
    }
}