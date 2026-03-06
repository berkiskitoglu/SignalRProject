using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.MenuTableDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Controllers
{
    public class MenuTableController : Controller
    {
        private readonly IMenuTableApiService _menuTableApiService;
        private readonly IMapper _mapper;

        public MenuTableController(IMenuTableApiService menuTableApiService, IMapper mapper)
        {
            _menuTableApiService = menuTableApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> MenuTableList()
        {
            var values = await _menuTableApiService.GetAllAsync();
            var viewModels = _mapper.Map<List<MenuTableViewModel>>(values);
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult CreateMenuTable()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            if (!ModelState.IsValid)
                return View(createMenuTableDto);

            createMenuTableDto.Status = true;
            await _menuTableApiService.CreateAsync(createMenuTableDto);
            return RedirectToAction("MenuTableList");
        }

        public async Task<IActionResult> DeleteMenuTable(int id)
        {
            await _menuTableApiService.DeleteAsync(id);
            return RedirectToAction("MenuTableList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMenuTable(int id)
        {
            var value = await _menuTableApiService.GetByIdAsync(id);
            if (value is null) return NotFound();
            var dto = _mapper.Map<UpdateMenuTableDto>(value);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMenuTable(int id, UpdateMenuTableDto updateMenuTableDto)
        {
            if (!ModelState.IsValid)
                return View(updateMenuTableDto);

            await _menuTableApiService.UpdateAsync(id, updateMenuTableDto);
            return RedirectToAction("MenuTableList");
        }

        [HttpGet]
        public async Task<IActionResult> TableListByStatus()
        {
            var values = await _menuTableApiService.GetAllAsync();
            var viewModels = _mapper.Map<List<MenuTableViewModel>>(values);
            return View(viewModels);
        }
    }
}