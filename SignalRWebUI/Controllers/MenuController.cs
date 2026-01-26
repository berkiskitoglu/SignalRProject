using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Services.Abstract;
using System.Threading.Tasks;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IProductApiService _productApiService;

        public MenuController(IProductApiService productApiService)
        {
            _productApiService = productApiService;
        }

        public async Task<IActionResult> Index() => View(await _productApiService.GetAllAsync());

    }
}
