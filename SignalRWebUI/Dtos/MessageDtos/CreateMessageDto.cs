using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
        [Required(ErrorMessage = "Ad Soyad zorunludur")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Ad Soyad en az 3, en fazla 100 karakter olmalıdır")]
        [Display(Name = "Ad Soyad")]
        public string NameSurname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        [Display(Name = "Email")]
        public string Mail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon zorunludur")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Telefon en az 10, en fazla 20 karakter olmalıdır")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Konu zorunludur")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Konu en az 3, en fazla 200 karakter olmalıdır")]
        [Display(Name = "Konu")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mesaj içeriği zorunludur")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Mesaj içeriği en az 10, en fazla 1000 karakter olmalıdır")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Mesaj İçeriği")]
        public string MessageContent { get; set; } = string.Empty;

        public DateTime MessageSendDate { get; set; } = DateTime.Now;

        public bool Status { get; set; }
    }
}