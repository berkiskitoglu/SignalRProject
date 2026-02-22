using System;
using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class BookingViewModel
    {
        public int? BookingID { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [StringLength(100, MinimumLength = 2,
            ErrorMessage = "Ad en az 2, en fazla 100 karakter olmalıdır")]
        [Display(Name = "Ad Soyad")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon numarası zorunludur")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email alanı zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        [Display(Name = "Email")]
        public string Mail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kişi sayısı zorunludur")]
        [Range(1, 100, ErrorMessage = "Kişi sayısı 1 ile 100 arasında olmalıdır")]
        [Display(Name = "Kişi Sayısı")]
        public int PersonCount { get; set; }

        [Required(ErrorMessage = "Tarih seçimi zorunludur")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Rezervasyon Tarihi")]
        [FutureDate(ErrorMessage = "Geçmiş tarihleri seçemezsiniz")]
        public DateTime Date { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime date)
            {
                return date > DateTime.Now;
            }
            return false;
        }
    }
}