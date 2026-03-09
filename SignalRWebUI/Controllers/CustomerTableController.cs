using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels.MenuTableViewModels;

namespace SignalRWebUI.Controllers
{
    public class CustomerTableController : Controller
    {
        private readonly IMenuTableApiService _menuTableApiService;
        private readonly IMapper _mapper;

        public CustomerTableController(IMenuTableApiService menuTableApiService, IMapper mapper)
        {
            _menuTableApiService = menuTableApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> CustomerTableList()
        {
            var result = await _menuTableApiService.GetAllAsync();
            var viewModels = _mapper.Map<List<ResultMenuTableViewModel>>(result);
            return View(viewModels);
        }
    }
}
