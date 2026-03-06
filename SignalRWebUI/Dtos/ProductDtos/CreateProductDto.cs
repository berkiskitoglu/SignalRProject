using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Ürün adı zorunludur")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Ürün adı en az 3, en fazla 200 karakter olmalıdır")]
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açıklama zorunludur")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Açıklama en az 3, en fazla 500 karakter olmalıdır")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fiyat zorunludur")]
        [Range(0.01, 10000, ErrorMessage = "Fiyat 0.01 ile 10000 arasında olmalıdır")]
        [DataType(DataType.Currency)]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Resim URL'si zorunludur")]
        [Url(ErrorMessage = "Geçerli bir URL giriniz")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "URL en az 10, en fazla 500 karakter olmalıdır")]
        [Display(Name = "Resim URL'si")]
        public string ImageUrl { get; set; } = string.Empty;

        public bool ProductStatus { get; set; }

        [Required(ErrorMessage = "Kategori zorunludur")]
        [Display(Name = "Kategori")]
        public int CategoryID { get; set; }
    }
}