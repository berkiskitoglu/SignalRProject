using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class ProductViewModel
    {
        public int? ProductID { get; set; }

        [Required(ErrorMessage = "Ürün adı zorunludur")]
        [StringLength(200, MinimumLength = 2,
            ErrorMessage = "Ürün adı en az 2, en fazla 200 karakter olmalıdır")]
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; } = string.Empty;

        [StringLength(1000, MinimumLength = 10,
            ErrorMessage = "Açıklama en az 10, en fazla 1000 karakter olmalıdır")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur")]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Fiyat 0'dan büyük olmalıdır")]
        [DataType(DataType.Currency)]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Resim URL'si zorunludur")]
        [Url(ErrorMessage = "Geçerli bir URL giriniz")]
        [StringLength(500, MinimumLength = 10,
            ErrorMessage = "URL en az 10, en fazla 500 karakter olmalıdır")]
        [Display(Name = "Resim URL'si")]
        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "Aktif")]
        public bool ProductStatus { get; set; }

        [Required(ErrorMessage = "Kategori seçimi zorunludur")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir kategori seçiniz")]
        [Display(Name = "Kategori")]
        public int CategoryID { get; set; }

        [Display(Name = "Kategoriler")]
        public List<SelectListItem> CategoryList { get; set; } = new();
    }
}