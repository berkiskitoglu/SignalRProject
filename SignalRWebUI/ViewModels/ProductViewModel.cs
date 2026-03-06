using Microsoft.AspNetCore.Mvc.Rendering;

namespace SignalRWebUI.ViewModels
{
    public class ProductViewModel
    {
        public int? ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool ProductStatus { get; set; }
        public int CategoryID { get; set; }
        public List<SelectListItem> CategoryList { get; set; } = new();
    }
}