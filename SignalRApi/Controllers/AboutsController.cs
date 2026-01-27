using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDtos;
using SignalR.EntityLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutsController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
            => Ok(_mapper.Map<List<ResultAboutDto>>(await _aboutService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            var about = _mapper.Map<About>(createAboutDto);
            await _aboutService.TAddAsync(about);
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
                return NotFound();
            var dto = _mapper.Map<ResultAboutDto>(about);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAbout(int id, UpdateAboutDto updateAboutDto)
        {
            var about = await _aboutService.TGetByIDAsync(id);
            if (about == null)
                return NotFound("Hakkımda bilgisi bulunamadı");
            _mapper.Map(updateAboutDto, about);
            await _aboutService.TUpdateAsync(about);
            return Ok("Hakkımda Bilgisi Güncellendi");
        }
    }
}