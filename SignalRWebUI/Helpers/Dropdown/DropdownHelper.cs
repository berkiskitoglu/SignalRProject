using Microsoft.AspNetCore.Mvc.Rendering;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels.ProductViewModels;

namespace SignalRWebUI.Helpers.Dropdown
{
    public class DropdownHelper : IDropdownHelper
    {
        private readonly ICategoryApiService _categoryApiService;

        public DropdownHelper(ICategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async Task<List<SelectListItem>> GetCategoryDropdownAsync()
        {
            var categories = await _categoryApiService.GetAllAsync();
            return categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            }).ToList();
        }

        public async Task<CreateProductViewModel> BuildCreateProductViewModelAsync()
        {
            return new CreateProductViewModel
            {
                ProductStatus = true,
                CategoryList = await GetCategoryDropdownAsync()
            };
        }

        public async Task<UpdateProductViewModel> BuildUpdateProductViewModelAsync(int id)
        {
            return new UpdateProductViewModel
            {
                ProductID = id,
                CategoryList = await GetCategoryDropdownAsync()
            };
        }
    }
}