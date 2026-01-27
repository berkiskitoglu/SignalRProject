using AutoMapper;
using SignalR.DtoLayer.TestimonialDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial, ResultTestimonialDto>();
            CreateMap<Testimonial, GetTestimonialDto>();

            CreateMap<CreateTestimonialDto, Testimonial>();
            CreateMap<UpdateTestimonialDto, Testimonial>();
        }
    }
}
