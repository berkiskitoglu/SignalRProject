using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class CreateBasketProductViewModel
    {
        public int BasketID { get; set; }

        public int ProductID { get; set; }

        [Required(ErrorMessage = "Ürün adı zorunludur")]
        [StringLength(250, MinimumLength = 2,
            ErrorMessage = "Ürün adı en az 2, en fazla 250 karakter olmalıdır")]
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Miktar zorunludur")]
        [Range(1, 1000,
            ErrorMessage = "Miktar 1 ile 1000 arasında olmalıdır")]
        [Display(Name = "Miktar")]
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }
    }
}