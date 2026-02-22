using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class TestimonialViewModel
    {
        public int? TestimonialID { get; set; }

        [Required(ErrorMessage = "Ad zorunludur")]
        [StringLength(100, MinimumLength = 2,
            ErrorMessage = "Ad en az 2, en fazla 100 karakter olmalıdır")]
        [Display(Name = "Ad")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Başlık zorunludur")]
        [StringLength(150, MinimumLength = 3,
            ErrorMessage = "Başlık en az 3, en fazla 150 karakter olmalıdır")]
        [Display(Name = "Başlık")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yorum zorunludur")]
        [StringLength(1000, MinimumLength = 10,
            ErrorMessage = "Yorum en az 10, en fazla 1000 karakter olmalıdır")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Yorum")]
        public string Comment { get; set; } = string.Empty;

        [Required(ErrorMessage = "Resim URL'si zorunludur")]
        [Url(ErrorMessage = "Geçerli bir URL giriniz")]
        [StringLength(500, MinimumLength = 10,
            ErrorMessage = "URL en az 10, en fazla 500 karakter olmalıdır")]
        [Display(Name = "Resim URL'si")]
        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "Aktif")]
        public bool Status { get; set; }
    }
}