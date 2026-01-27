namespace SignalRWebUI.ViewModels
{
    public class CreateBasketViewModel
    {
        public int ProductID { get; set; }
        public string Status { get; set; }
        public int MenuTableID { get; set; }
        public List<BasketProductViewModel> Products { get; set; }
    }
}
