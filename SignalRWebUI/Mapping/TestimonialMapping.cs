using AutoMapper;
using SignalRWebUI.Dtos.TestimonialDtos;
using SignalRWebUI.ViewModels.TestimonialViewModels;

namespace SignalRWebUI.Mapping
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<ResultTestimonialDto, ResultTestimonialViewModel>();
            CreateMap<GetTestimonialDto, UpdateTestimonialViewModel>();
            CreateMap<CreateTestimonialViewModel, CreateTestimonialDto>();
            CreateMap<UpdateTestimonialViewModel, UpdateTestimonialDto>();
        }
    }
}