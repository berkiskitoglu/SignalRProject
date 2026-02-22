using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class DiscountViewModel
    {
        public int? DiscountID { get; set; }

        [Required(ErrorMessage = "Başlık zorunludur")]
        [StringLength(200, MinimumLength = 3,
            ErrorMessage = "Başlık en az 3, en fazla 200 karakter olmalıdır")]
        [Display(Name = "Başlık")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "İndirim miktarı zorunludur")]
        [Range(1, 100,
            ErrorMessage = "İndirim miktarı 1 ile 100 arasında olmalıdır")]
        [Display(Name = "İndirim Miktarı (%)")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur")]
        [StringLength(500, MinimumLength = 10,
            ErrorMessage = "Açıklama en az 10, en fazla 500 karakter olmalıdır")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Resim URL'si zorunludur")]
        [Url(ErrorMessage = "Geçerli bir URL giriniz")]
        [StringLength(500, MinimumLength = 10,
            ErrorMessage = "URL en az 10, en fazla 500 karakter olmalıdır")]
        [Display(Name = "Resim URL'si")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}