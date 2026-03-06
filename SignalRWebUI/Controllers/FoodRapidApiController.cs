using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Controllers
{
    public class FoodRapidApiController : Controller
    {

        private readonly ITastyApiService _tastyApiService;

        public FoodRapidApiController(ITastyApiService tastyApiService)
        {
            _tastyApiService = tastyApiService;
        }

        public async Task<IActionResult> Index()
        {
          var values = await _tastyApiService.GetRecipesAsync();
          return View(values);
        }
    }
}
