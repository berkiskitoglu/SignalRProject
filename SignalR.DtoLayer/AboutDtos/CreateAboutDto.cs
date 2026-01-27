namespace SignalR.DtoLayer.AboutDtos
{
    public class CreateAboutDto
    {
        public required string ImageUrl { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
