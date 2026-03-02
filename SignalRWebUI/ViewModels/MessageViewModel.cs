using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class MessageViewModel
    {
        public int? MessageID { get; set; }

        [Required(ErrorMessage = "Ad Soyad zorunludur")]
        [StringLength(150, MinimumLength = 3,
            ErrorMessage = "Ad Soyad en az 3, en fazla 150 karakter olmalıdır")]
        [Display(Name = "Ad Soyad")]
        public string? NameSurname { get; set; }

        [Required(ErrorMessage = "Email zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        [Display(Name = "Email")]
        public string? Mail { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Konu zorunludur")]
        [StringLength(200, MinimumLength = 3,
            ErrorMessage = "Konu en az 3, en fazla 200 karakter olmalıdır")]
        [Display(Name = "Konu")]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "Mesaj zorunludur")]
        [StringLength(1000, MinimumLength = 10,
            ErrorMessage = "Mesaj en az 10, en fazla 1000 karakter olmalıdır")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Mesaj")]
        public string? MessageContent { get; set; }

        [Display(Name = "Gönderim Tarihi")]
        public DateTime MessageSendDate { get; set; }

        [Display(Name = "Aktif")]
        public bool Status { get; set; }
    }
}