using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Services.Abstract;
using System.Threading.Tasks;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuComponentPartial : ViewComponent
    {
        private readonly IProductApiService _productApiService;

        public _DefaultOurMenuComponentPartial(IProductApiService productApiService)
        {
            _productApiService = productApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await _productApiService.GetAllAsync());
        
        
    }
}
