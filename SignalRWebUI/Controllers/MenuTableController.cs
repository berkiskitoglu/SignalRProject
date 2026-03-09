using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.MenuTableDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels.MenuTableViewModels;

namespace SignalRWebUI.Controllers
{
    public class MenuTableController : Controller
    {
        private readonly IMenuTableApiService _menuTableApiService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public MenuTableController(IMenuTableApiService menuTableApiService, IMapper mapper, IConfiguration configuration)
        {
            _menuTableApiService = menuTableApiService;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IActionResult> MenuTableList()
        {
            List<ResultMenuTableDto> values = await _menuTableApiService.GetAllAsync();
            List<ResultMenuTableViewModel> resultMenuTableViewModels = _mapper.Map<List<ResultMenuTableViewModel>>(values);
            return View(resultMenuTableViewModels);
        }

        [HttpGet]
        public IActionResult CreateMenuTable() => View();

        [HttpPost]
        public async Task<IActionResult> CreateMenuTable(CreateMenuTableViewModel createMenuTableViewModel)
        {
            if (!ModelState.IsValid)
                return View(createMenuTableViewModel);

            CreateMenuTableDto createMenuTableDto = _mapper.Map<CreateMenuTableDto>(createMenuTableViewModel);
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
            GetMenuTableDto getMenuTableDto = await _menuTableApiService.GetByIdAsync(id);
            if (getMenuTableDto is null) return NotFound();
            UpdateMenuTableViewModel updateMenuTableViewModel = _mapper.Map<UpdateMenuTableViewModel>(getMenuTableDto);
            return View(updateMenuTableViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMenuTable(int id, UpdateMenuTableViewModel updateMenuTableViewModel)
        {
            if (!ModelState.IsValid)
                return View(updateMenuTableViewModel);

            UpdateMenuTableDto updateMenuTableDto = _mapper.Map<UpdateMenuTableDto>(updateMenuTableViewModel);
            await _menuTableApiService.UpdateAsync(id, updateMenuTableDto);
            return RedirectToAction("MenuTableList");
        }

        [HttpGet]
        public IActionResult TableListByStatus()
        {
            ViewBag.HubUrl = _configuration["ApiSettings:BaseUrl"] + "SignalRHub";
            return View();
        }
    }
}