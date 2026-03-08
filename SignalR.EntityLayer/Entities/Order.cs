namespace SignalR.EntityLayer.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Description { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public int MenuTableID { get; set; }
        public int? BasketID { get; set; }
        public MenuTable MenuTable { get; set; } = null!;
        public Basket? Basket { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = null!;
    }
}
