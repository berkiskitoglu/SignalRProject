using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels.SocialMediaViewModels
{
    public class CreateSocialMediaViewModel
    {
        [Required(ErrorMessage = "Başlık zorunludur")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Başlık en az 2, en fazla 100 karakter olmalıdır")]
        [Display(Name = "Başlık")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "İkon zorunludur")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "İkon en az 2, en fazla 100 karakter olmalıdır")]
        [Display(Name = "İkon")]
        public string Icon { get; set; } = string.Empty;

        [Required(ErrorMessage = "URL zorunludur")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "URL en az 3, en fazla 500 karakter olmalıdır")]
        [Display(Name = "URL")]
        public string Url { get; set; } = string.Empty;
    }
}