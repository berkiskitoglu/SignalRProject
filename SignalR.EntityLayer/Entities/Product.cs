namespace SignalR.EntityLayer.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public bool ProductStatus { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; } = null!;
        public List<OrderDetail> OrderDetails { get; set; } = null!;

    }
}
