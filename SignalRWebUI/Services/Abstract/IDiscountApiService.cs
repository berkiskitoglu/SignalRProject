using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.DiscountDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface IDiscountApiService : IGenericApiService<ResultDiscountDto,CreateDiscountDto,UpdateDiscountDto,GetDiscountDto>
    {
        Task ChangeStatusToFalse(int id);
        Task ChangeStatusToTrue(int id);
        Task<List<ResultDiscountDto>> GetAllActiveDiscounts();


    }
}
