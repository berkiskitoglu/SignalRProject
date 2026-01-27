namespace SignalR.DtoLayer.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public required string Name { get; set; } 
        public required string Title { get; set; } 
        public required string Comment { get; set; } 
        public required string ImageUrl { get; set; } 
        public required bool Status { get; set; }
    }
}
