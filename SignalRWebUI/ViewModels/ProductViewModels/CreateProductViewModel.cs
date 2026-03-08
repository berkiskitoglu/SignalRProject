using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels.ProductViewModels
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Ürün adı zorunludur")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Ürün adı en az 3, en fazla 200 karakter olmalıdır")]
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; } = string.Empty;

        [StringLength(500, MinimumLength = 3, ErrorMessage = "Açıklama en az 3, en fazla 500 karakter olmalıdır")]
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur")]
        [Range(0.01, 10000, ErrorMessage = "Fiyat 0.01 ile 10000 arasında olmalıdır")]
        [Display(Name = "Fiyat")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Resim URL'si zorunludur")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "URL en az 3, en fazla 500 karakter olmalıdır")]
        [Display(Name = "Resim URL'si")]
        public string ImageUrl { get; set; } = string.Empty;

        public bool ProductStatus { get; set; }

        [Required(ErrorMessage = "Kategori seçimi zorunludur")]
        [Display(Name = "Kategori")]
        public int CategoryID { get; set; }

        public List<SelectListItem> CategoryList { get; set; } = new();
    }
}