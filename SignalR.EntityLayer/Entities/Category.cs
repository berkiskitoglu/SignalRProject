namespace SignalR.EntityLayer.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = null!;
        public bool Status { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

    }

}
