using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.Dtos.SliderDtos
{
    public class UpdateSliderDto
    {
        public int SliderID { get; set; }

        [Required(ErrorMessage = "Başlık 1 zorunludur")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Başlık 1 en az 3, en fazla 200 karakter olmalıdır")]
        [Display(Name = "Başlık 1")]
        public string Title1 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açıklama 1 zorunludur")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Açıklama 1 en az 3, en fazla 500 karakter olmalıdır")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Açıklama 1")]
        public string Description1 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Başlık 2 zorunludur")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Başlık 2 en az 3, en fazla 200 karakter olmalıdır")]
        [Display(Name = "Başlık 2")]
        public string Title2 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açıklama 2 zorunludur")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Açıklama 2 en az 3, en fazla 500 karakter olmalıdır")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Açıklama 2")]
        public string Description2 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Başlık 3 zorunludur")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Başlık 3 en az 3, en fazla 200 karakter olmalıdır")]
        [Display(Name = "Başlık 3")]
        public string Title3 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açıklama 3 zorunludur")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Açıklama 3 en az 3, en fazla 500 karakter olmalıdır")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Açıklama 3")]
        public string Description3 { get; set; } = string.Empty;
    }
}