using SignalRWebUI.Dtos.SliderDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface ISliderApiService : IGenericApiService<ResultSliderDto,CreateSliderDto,UpdateSliderDto,GetSliderDto>
    {
    }
}
