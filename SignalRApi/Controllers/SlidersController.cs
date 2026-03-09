using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SliderDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateSliderDto> _createValidator;
        private readonly IValidator<UpdateSliderDto> _updateValidator;

        public SlidersController(
            ISliderService sliderService,
            IMapper mapper,
            IValidator<CreateSliderDto> createValidator,
            IValidator<UpdateSliderDto> updateValidator)
        {
            _sliderService = sliderService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> SliderList()
            => Ok(_mapper.Map<List<ResultSliderDto>>(await _sliderService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            var validationResult = await _createValidator.ValidateAsync(createSliderDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            await _sliderService.TAddAsync(_mapper.Map<Slider>(createSliderDto));
            return Ok("Slider Alanı Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var itemToDelete = await _sliderService.TGetByIDAsync(id);
            if (itemToDelete == null)
                return NotFound("Slider Alanı bulunamadı");

            await _sliderService.TDeleteAsync(itemToDelete);
            return Ok("Slider Alanı Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlider(int id)
        {
            var slider = await _sliderService.TGetByIDAsync(id);
            if (slider == null)
                return NotFound("Slider Alanı bulunamadı");

            return Ok(_mapper.Map<ResultSliderDto>(slider));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlider(int id, UpdateSliderDto updateSliderDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateSliderDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            var slider = await _sliderService.TGetByIDAsync(id);
            if (slider == null)
                return NotFound("Slider Alanı bulunamadı");

            _mapper.Map(updateSliderDto, slider);
            await _sliderService.TUpdateAsync(slider);
            return Ok("Slider Alan Güncellendi");
        }
    }
}