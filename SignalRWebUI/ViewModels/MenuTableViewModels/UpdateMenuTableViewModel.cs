using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels.MenuTableViewModels
{
    public class UpdateMenuTableViewModel
    {
        public int MenuTableID { get; set; }

        [Required(ErrorMessage = "Masa adı zorunludur")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Masa adı en az 2, en fazla 50 karakter olmalıdır")]
        [Display(Name = "Masa Adı")]
        public string Name { get; set; } = string.Empty;

        public bool Status { get; set; }
    }
}