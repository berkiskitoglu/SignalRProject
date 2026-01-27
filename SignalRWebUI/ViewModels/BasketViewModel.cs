namespace SignalRWebUI.ViewModels
{
    public class BasketViewModel
    {
        public int BasketID { get; set; }
        public int MenuTableID { get; set; }

        public IEnumerable<BasketProductViewModel> Products { get; set; }
    }

}
