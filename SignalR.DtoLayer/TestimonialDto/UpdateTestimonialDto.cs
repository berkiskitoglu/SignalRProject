namespace SignalR.DtoLayer.TestimonialDto
{
    public class UpdateTestimonialDto
    {
        public int TestimonialID { get; set; }
        public required string Name { get; set; } 
        public required string Title { get; set; } 
        public required string Comment { get; set; } 
        public required string ImageUrl { get; set; } 
        public required bool Status { get; set; }
    }
}
