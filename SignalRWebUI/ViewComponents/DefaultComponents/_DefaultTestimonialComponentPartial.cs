using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Services.Abstract;
using System.Threading.Tasks;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultTestimonialComponentPartial : ViewComponent
    {
        private readonly ITestimonialApiService _testimonialApiService;

        public _DefaultTestimonialComponentPartial(ITestimonialApiService testimonialApiService)
        {
            _testimonialApiService = testimonialApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await _testimonialApiService.GetAllAsync());
    }
}
