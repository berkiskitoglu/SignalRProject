using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutsController(IAboutService AboutService, IMapper mapper)
        {
            _aboutService = AboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var aboutList = _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetListAll());
            return Ok(aboutList);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var about = _mapper.Map<About>(createAboutDto);
            _aboutService.TAdd(about);
            return Ok("Hakkımda Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var itemToDelete = _aboutService.TGetByID(id);
            _aboutService.TDelete(itemToDelete);
            return Ok("Hakkımda Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var about= _aboutService.TGetByID(id);
            if (about == null)
                return NotFound();

            var dto = _mapper.Map<ResultAboutDto>(about);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAbout(int id , UpdateAboutDto updateAboutDto)
        {

            var about = _aboutService.TGetByID(id);
            if (about is null)
                return NotFound("Hakkımda bilgisi bulunamadı");
            _mapper.Map(updateAboutDto, about);

            _aboutService.TUpdate(about);

            return Ok("Hakkımda Bilgisi Güncellendi");
        }
    }
}
