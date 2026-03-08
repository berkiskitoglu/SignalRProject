using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels.DiscountViewModels
{
    public class CreateDiscountViewModel
    {
        [Required(ErrorMessage = "Başlık zorunludur")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Başlık en az 3, en fazla 200 karakter olmalıdır")]
        [Display(Name = "Başlık")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Miktar zorunludur")]
        [Range(1, 100, ErrorMessage = "Miktar 1 ile 100 arasında olmalıdır")]
        [Display(Name = "Miktar")]
        public int? Amount { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Açıklama en az 3, en fazla 500 karakter olmalıdır")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Resim URL'si zorunludur")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "URL en az 3, en fazla 500 karakter olmalıdır")]
        [Display(Name = "Resim URL'si")]
        public string ImageUrl { get; set; } = string.Empty;

        public bool Status { get; set; }
    }
}