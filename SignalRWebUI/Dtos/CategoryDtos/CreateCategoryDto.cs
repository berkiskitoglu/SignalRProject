using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Kategori adı zorunludur")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Kategori adı en az 3, en fazla 100 karakter olmalıdır")]
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; } = string.Empty;

        public bool Status { get; set; }
    }
}