namespace SignalRWebUI.Dtos.BasketProductDtos
{
    public class CreateBasketProductDto
    {
        public int BasketID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
