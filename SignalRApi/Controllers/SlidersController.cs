using AutoMapper;
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

        public SlidersController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SliderList()
            => Ok(_mapper.Map<List<ResultSliderDto>>(await _sliderService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            var Slider = _mapper.Map<Slider>(createSliderDto);
            await _sliderService.TAddAsync(Slider);
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
            var Slider = await _sliderService.TGetByIDAsync(id);
            if (Slider == null)
                return NotFound();
            var dto = _mapper.Map<ResultSliderDto>(Slider);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlider(int id, UpdateSliderDto updateSliderDto)
        {
            var Slider = await _sliderService.TGetByIDAsync(id);
            if (Slider == null)
                return NotFound("Slider Alanı bulunamadı");
            _mapper.Map(updateSliderDto, Slider);
            await _sliderService.TUpdateAsync(Slider);
            return Ok("Slider Alan Güncellendi");
        }
    }
}