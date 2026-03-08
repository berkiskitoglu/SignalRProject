namespace SignalRWebUI.ViewModels.ProductViewModels
{
    public class ProductListViewModel
    {
        public List<ResultProductViewModel> Products { get; set; } = new();
        public List<string?> Categories { get; set; } = new();
    }
}