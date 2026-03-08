using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels.TestimonialViewModels
{
    public class CreateTestimonialViewModel
    {
        [Required(ErrorMessage = "Ad zorunludur")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Ad en az 2, en fazla 100 karakter olmalıdır")]
        [Display(Name = "Ad")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Unvan zorunludur")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Unvan en az 2, en fazla 100 karakter olmalıdır")]
        [Display(Name = "Unvan")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yorum zorunludur")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Yorum en az 10, en fazla 1000 karakter olmalıdır")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Yorum")]
        public string Comment { get; set; } = string.Empty;

        [Required(ErrorMessage = "Resim URL'si zorunludur")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "URL en az 3, en fazla 500 karakter olmalıdır")]
        [Display(Name = "Resim URL'si")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}