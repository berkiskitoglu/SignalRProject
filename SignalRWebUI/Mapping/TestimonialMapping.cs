using AutoMapper;
using SignalRWebUI.Dtos.TestimonialDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<GetTestimonialDto, TestimonialViewModel>();
            CreateMap<TestimonialViewModel, CreateTestimonialDto>();
            CreateMap<TestimonialViewModel, UpdateTestimonialDto>();
        }
    }
}
