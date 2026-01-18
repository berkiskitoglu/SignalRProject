namespace SignalR.EntityLayer.Entities
{
    public class About
    {
        public int AboutID { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
