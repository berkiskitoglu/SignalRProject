using SignalRWebUI.Dtos.BasketDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface IBasketApiService : IGetByIdListApiService<ResultBasketDto>
    {
        Task CreateAsync(CreateBasketDto createBasketDto);
    }
}
