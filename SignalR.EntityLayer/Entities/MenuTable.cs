namespace SignalR.EntityLayer.Entities
{
    public class MenuTable
    {
        public int MenuTableID { get; set; }
        public string Name { get; set; } = null!;
        public bool Status { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Basket> Baskets { get; set; } = new List<Basket>();
    }
}
