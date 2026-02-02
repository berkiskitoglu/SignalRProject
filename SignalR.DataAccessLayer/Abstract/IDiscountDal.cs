using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IDiscountDal : IGenericDal<Discount>
    {
        Task ChangeStatusToTrue(int id);
        Task ChangeStatusToFalse(int id);

        Task<List<Discount>> GetAllActiveDiscounts();
    }
}
