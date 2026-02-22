using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class NotificationViewModel
    {
        public int NotificationID { get; set; }

        [Required(ErrorMessage = "Bildirim türü zorunludur")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Bildirim türü en az 2, en fazla 50 karakter olmalıdır")]
        [Display(Name = "Bildirim Türü")]
        public string Type { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açıklama zorunludur")]
        [StringLength(500, MinimumLength = 5,
            ErrorMessage = "Açıklama en az 5, en fazla 500 karakter olmalıdır")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "İkon zorunludur")]
        [StringLength(100, MinimumLength = 2,
            ErrorMessage = "İkon en az 2, en fazla 100 karakter olmalıdır")]
        [Display(Name = "İkon")]
        public string Icon { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tarih zorunludur")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Tarih")]
        public DateTime Date { get; set; }

        public bool Status { get; set; }
    }
}