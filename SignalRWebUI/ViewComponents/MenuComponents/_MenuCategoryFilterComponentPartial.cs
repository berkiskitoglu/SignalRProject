using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.ViewComponents.MenuComponents
{
    public class _MenuCategoryFilterComponentPartial : ViewComponent
    {
        private readonly ICategoryApiService _categoryApiService;

        public _MenuCategoryFilterComponentPartial(ICategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryList = await _categoryApiService.GetAllAsync();
            return View(categoryList);
        }
    }
}
