using Microsoft.AspNetCore.Mvc.Rendering;
using SignalRWebUI.ViewModels.ProductViewModels;

namespace SignalRWebUI.Helpers.Dropdown
{
    public interface IDropdownHelper
    {
        Task<List<SelectListItem>> GetCategoryDropdownAsync();
        Task<CreateProductViewModel> BuildCreateProductViewModelAsync();
        Task<UpdateProductViewModel> BuildUpdateProductViewModelAsync(int id);
    }
}