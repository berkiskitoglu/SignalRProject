using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class ProgressBarController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProgressBarController(IConfiguration configuration)
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
