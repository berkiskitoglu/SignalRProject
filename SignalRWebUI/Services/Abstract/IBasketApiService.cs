using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.BasketProductDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface IBasketApiService : IGetByIdListApiService<ResultBasketDto>
    {
        Task CreateAsync(CreateBasketDto createBasketDto);
    }
}
