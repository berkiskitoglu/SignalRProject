namespace SignalR.DtoLayer.SocialMediaDto
{
    public class UpdateSocialMediaDto
    {
        public int SocialMediaID { get; set; }

        public required string Title { get; set; }
        public required string Url { get; set; }
        public required string Icon { get; set; }
    }
}
