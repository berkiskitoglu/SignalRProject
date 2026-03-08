namespace SignalRWebUI.ViewModels.BasketViewModels
{
    public class ResultBasketViewModel
    {
        public int BasketID { get; set; }
        public int MenuTableID { get; set; }
        public string Status { get; set; } = string.Empty;
        public IEnumerable<ResultBasketProductViewModel> Products { get; set; } = Enumerable.Empty<ResultBasketProductViewModel>();
    }
}