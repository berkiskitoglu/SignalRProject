using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        [Required(ErrorMessage = "Konum zorunludur")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Konum en az 3, en fazla 200 karakter olmalıdır")]
        [Display(Name = "Konum")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon zorunludur")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Telefon en az 10, en fazla 20 karakter olmalıdır")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        [Display(Name = "Email")]
        public string Mail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Footer açıklaması zorunludur")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Footer açıklaması en az 3, en fazla 500 karakter olmalıdır")]
        [Display(Name = "Footer Açıklaması")]
        public string FooterDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Footer başlığı zorunludur")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Footer başlığı en az 3, en fazla 200 karakter olmalıdır")]
        [Display(Name = "Footer Başlığı")]
        public string FooterTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açık günler zorunludur")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Açık günler en az 3, en fazla 100 karakter olmalıdır")]
        [Display(Name = "Açık Günler")]
        public string OpenDays { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açık günler açıklaması zorunludur")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Açık günler açıklaması en az 3, en fazla 200 karakter olmalıdır")]
        [Display(Name = "Açık Günler Açıklaması")]
        public string OpenDaysDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açık saatler zorunludur")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Açık saatler en az 3, en fazla 100 karakter olmalıdır")]
        [Display(Name = "Açık Saatler")]
        public string OpenHours { get; set; } = string.Empty;
    }
}