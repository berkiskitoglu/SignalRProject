using SignalRWebUI.Dtos.TestimonialDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface ITestimonialApiService : IGenericApiService<ResultTestimonialDto,CreateTestimonialDto,UpdateTestimonialDto,GetTestimonialDto>
    {
    }
}
