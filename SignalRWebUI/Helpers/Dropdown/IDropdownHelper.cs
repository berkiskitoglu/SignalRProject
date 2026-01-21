using Microsoft.AspNetCore.Mvc.Rendering;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Helpers.Dropdown
{
    public interface IDropdownHelper
    {
        Task<List<SelectListItem>> GetCategoryDropdownAsync();
        Task<ProductViewModel> BuildProductViewModelAsync();
    }
}
