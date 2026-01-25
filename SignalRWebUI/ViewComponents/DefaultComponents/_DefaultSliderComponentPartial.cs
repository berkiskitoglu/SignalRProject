using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultSliderComponentPartial : ViewComponent
    {
        private readonly ISliderApiService _sliderApiService;

        public _DefaultSliderComponentPartial(ISliderApiService sliderApiService)
        {
            _sliderApiService = sliderApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliderList = await _sliderApiService.GetAllAsync();
            return View(sliderList);
        }
    }
}
