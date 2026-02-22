using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class CategoryViewModel
    {
        public int? CategoryID { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur")]
        [StringLength(150, MinimumLength = 2,
            ErrorMessage = "Kategori adı en az 2, en fazla 150 karakter olmalıdır")]
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Durum zorunludur")]
        [Display(Name = "Aktif")]
        public bool Status { get; set; }
    }
}