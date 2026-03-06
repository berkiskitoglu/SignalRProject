using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.ViewModels
{
    public class ProductListViewModel
    {
        public List<ResultProductWithCategoryDto> Products { get; set; } = new();
        public List<string> Categories { get; set; } = new();
    }
}