using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterComponentPartial : ViewComponent
    {
        private readonly IContactApiService _contactApiService;

        public _UILayoutFooterComponentPartial(IContactApiService contactApiService)
        {
            _contactApiService = contactApiService;
        }


        public async Task<IViewComponentResult> InvokeAsync() => View(await _contactApiService.GetAllAsync());

    }
}
