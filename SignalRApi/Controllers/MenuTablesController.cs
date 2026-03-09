using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<CreateMenuTableDto> _createValidator;
        private readonly IValidator<UpdateMenuTableDto> _updateValidator;

        public MenuTablesController(
            IMenuTableService menuTableService,
            IMapper mapper,
            IValidator<CreateMenuTableDto> createValidator,
            IValidator<UpdateMenuTableDto> updateValidator)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> MenuTableList()
            => Ok(_mapper.Map<List<ResultMenuTableDto>>(await _menuTableService.TGetListAllAsync()));

        [HttpGet("MenuTableCount")]
        public async Task<IActionResult> MenuTableCount()
            => Ok(await _menuTableService.TMenuTableCount());

        [HttpPost]
        public async Task<IActionResult> CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            var validationResult = await _createValidator.ValidateAsync(createMenuTableDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            await _menuTableService.TAddAsync(_mapper.Map<MenuTable>(createMenuTableDto));
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
            var menuTable = await _menuTableService.TGetByIDAsync(id);
            if (menuTable == null)
                return NotFound("Masa bilgisi bulunamadı");

            return Ok(_mapper.Map<ResultMenuTableDto>(menuTable));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuTable(int id, UpdateMenuTableDto updateMenuTableDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateMenuTableDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            var menuTable = await _menuTableService.TGetByIDAsync(id);
            if (menuTable == null)
                return NotFound("Masa bilgisi bulunamadı");

            _mapper.Map(updateMenuTableDto, menuTable);
            await _menuTableService.TUpdateAsync(menuTable);
            return Ok("Masa Bilgisi Güncellendi");
        }
        [HttpGet("ChangeMenuTableStatusToTrue/{id}")]  // ✅ DOĞRU
        public async Task<IActionResult> ChangeMenuTableStatusToTrue(int id)
        {
            var menuTable = await _menuTableService.TGetByIDAsync(id);
            if (menuTable == null)
                return NotFound("Masa bilgisi bulunamadı");

            menuTable.Status = true;
            await _menuTableService.TUpdateAsync(menuTable);
            return Ok("Masa Durumu Aktif Olarak Güncellendi");
        }

        [HttpGet("ChangeMenuTableStatusToFalse/{id}")]  // ✅ DOĞRU
        public async Task<IActionResult> ChangeMenuTableStatusToFalse(int id)
        {
            var menuTable = await _menuTableService.TGetByIDAsync(id);
            if (menuTable == null)
                return NotFound("Masa bilgisi bulunamadı");

            menuTable.Status = false;
            await _menuTableService.TUpdateAsync(menuTable);
            return Ok("Masa Durumu Pasif Olarak Güncellendi");
        }
    }
}