using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutNavbarComponentPartialViewComponent : ViewComponent
    {
        private readonly IConfiguration _configuration;

        public _LayoutNavbarComponentPartialViewComponent(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public  IViewComponentResult Invoke()
        {
            var hubUrl =  _configuration["ApiSettings:BaseUrl"] + "SignalRHub";
            return View(model: hubUrl);
        }
    }
}
