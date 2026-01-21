using SignalRWebUI.Dtos.DiscountDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface IDiscountApiService : IGenericApiService<ResultDiscountDto,CreateDiscountDto,UpdateDiscountDto,GetDiscountDto>
    {
    }
}
