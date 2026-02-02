using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IDiscountService : IGenericService<Discount>
    {
        Task TChangeStatusToTrue(int id);
        Task TChangeStatusToFalse(int id);
        Task<List<Discount>> TGetAllActiveDiscounts();

    }
}
