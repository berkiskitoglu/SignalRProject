using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IConfiguration _configuration;

        public StatisticController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.HubUrl = _configuration["ApiSettings:BaseUrl"] + "SignalRHub";
            return View();
        }
    }
}
