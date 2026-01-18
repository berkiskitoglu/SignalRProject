namespace SignalR.DtoLayer.AboutDto
{
    public class UpdateAboutDto
    {
        public int AboutID { get; set; }
        public required string ImageUrl { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
