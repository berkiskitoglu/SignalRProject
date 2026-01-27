namespace SignalR.DtoLayer.SocialMediaDtos
{
    public class GetSocialMediaDto
    {
        public int SocialMediaID { get; set; }
        public string Title { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string Icon { get; set; } = null!;
    }
}
