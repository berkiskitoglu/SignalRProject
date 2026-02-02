using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;


       
        [HttpGet("MenuTableCount")]
        public async Task<IActionResult> MenuTableCount() => Ok(await _menuTableService.TMenuTableCount());

        public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> MenuTableList()
            => Ok(_mapper.Map<List<ResultMenuTableDto>>(await _menuTableService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            var MenuTable = _mapper.Map<MenuTable>(createMenuTableDto);
            await _menuTableService.TAddAsync(MenuTable);
            return Ok("Masa Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuTable(int id)
        {
            var itemToDelete = await _menuTableService.TGetByIDAsync(id);
            if (itemToDelete == null)
                return NotFound("Masa bilgisi bulunamadı");
            await _menuTableService.TDeleteAsync(itemToDelete);
            return Ok("Masa Bilgisi Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuTable(int id)
        {
            var MenuTable = await _menuTableService.TGetByIDAsync(id);
            if (MenuTable == null)
                return NotFound();
            var dto = _mapper.Map<ResultMenuTableDto>(MenuTable);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuTable(int id, UpdateMenuTableDto updateMenuTableDto)
        {
            var MenuTable = await _menuTableService.TGetByIDAsync(id);
            if (MenuTable == null)
                return NotFound("Masa bilgisi bulunamadı");
            _mapper.Map(updateMenuTableDto, MenuTable);
            await _menuTableService.TUpdateAsync(MenuTable);
            return Ok("Masa Bilgisi Güncellendi");
        }
    }
}
