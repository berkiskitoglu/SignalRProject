using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class ProductViewModel
    {
        public int? ProductID { get; set; }  // Create: null, Update: dolu

        [Required]
        public string ProductName { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        public bool ProductStatus { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public List<SelectListItem> CategoryList { get; set; } = new();
    }

}
