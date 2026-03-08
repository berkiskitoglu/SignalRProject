using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels.BookingViewModels
{
    public class UpdateBookingViewModel
    {
        public int BookingID { get; set; }

        [Required(ErrorMessage = "Ad zorunludur")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Ad en az 3, en fazla 100 karakter olmalıdır")]
        [Display(Name = "Ad Soyad")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon zorunludur")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Telefon en az 10, en fazla 20 karakter olmalıdır")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        [Display(Name = "Email")]
        public string Mail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kişi sayısı zorunludur")]
        [Range(1, 50, ErrorMessage = "Kişi sayısı 1 ile 50 arasında olmalıdır")]
        [Display(Name = "Kişi Sayısı")]
        public int PersonCount { get; set; }

        [Required(ErrorMessage = "Tarih zorunludur")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Tarih")]
        public DateTime Date { get; set; }
    }
}