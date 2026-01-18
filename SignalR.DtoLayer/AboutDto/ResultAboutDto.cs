namespace SignalR.DtoLayer.AboutDto
{
    public class ResultAboutDto
    {
        public int AboutID { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
