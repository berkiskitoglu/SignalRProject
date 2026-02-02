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
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateMenuTable()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuTable(MenuTableViewModel MenuTableViewModel)
        {

            var createMenuTableDto = _mapper.Map<CreateMenuTableDto>(MenuTableViewModel);
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

            var viewModel = _mapper.Map<MenuTableViewModel>(value);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMenuTable(int id, MenuTableViewModel MenuTableViewModel)
        {

            var dto = _mapper.Map<UpdateMenuTableDto>(MenuTableViewModel);
            await _menuTableApiService.UpdateAsync(id, dto);
            return RedirectToAction("MenuTableList");
        }

        [HttpGet]
        public async Task<IActionResult> TableListByStatus()
        {
            var values = await _menuTableApiService.GetAllAsync();
            return View(values);

        }
    }
}
