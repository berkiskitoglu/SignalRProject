using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels.NotificationViewModels
{
    public class CreateNotificationViewModel
    {
        [Required(ErrorMessage = "Tür zorunludur")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Tür en az 2, en fazla 50 karakter olmalıdır")]
        [Display(Name = "Tür")]
        public string Type { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açıklama zorunludur")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Açıklama en az 3, en fazla 500 karakter olmalıdır")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "İkon zorunludur")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "İkon en az 2, en fazla 100 karakter olmalıdır")]
        [Display(Name = "İkon")]
        public string Icon { get; set; } = string.Empty;
    }
}