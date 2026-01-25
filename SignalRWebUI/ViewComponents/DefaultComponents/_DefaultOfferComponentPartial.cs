using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Services.Abstract;
using System.Threading.Tasks;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOfferComponentPartial : ViewComponent
    {
        private readonly IDiscountApiService _discountApiService;

        public _DefaultOfferComponentPartial(IDiscountApiService discountApiService)
        {
            _discountApiService = discountApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await _discountApiService.GetAllAsync());

    }
}
