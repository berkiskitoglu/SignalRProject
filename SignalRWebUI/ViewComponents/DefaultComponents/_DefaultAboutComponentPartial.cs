using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly IAboutApiService _aboutApiService;

        public _DefaultAboutComponentPartial(IAboutApiService aboutApiService)
        {
            _aboutApiService = aboutApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await _aboutApiService.GetAllAsync());
    }
}
