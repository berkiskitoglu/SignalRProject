using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels.BasketViewModels
{
    public class CreateBasketViewModel
    {
        public int ProductID { get; set; }
        public string Status { get; set; } = string.Empty;
        public int MenuTableID { get; set; }

        [Display(Name = "Ürünler")]
        public List<CreateBasketProductViewModel> Products { get; set; } = new List<CreateBasketProductViewModel>();
    }
}