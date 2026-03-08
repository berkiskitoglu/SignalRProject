using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels.MailViewModels
{
    public class CreateMailViewModel
    {
        [Required(ErrorMessage = "Alıcı mail zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        [Display(Name = "Alıcı Mail")]
        public string ReceiverMail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Konu zorunludur")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Konu en az 3, en fazla 200 karakter olmalıdır")]
        [Display(Name = "Konu")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "İçerik zorunludur")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "İçerik en az 10, en fazla 2000 karakter olmalıdır")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "İçerik")]
        public string Content { get; set; } = string.Empty;
    }
}