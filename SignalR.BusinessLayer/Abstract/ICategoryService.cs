using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<int> TCategoryCountAsync();
        Task<int> TActiveCategoryCount();
        Task<int> TPassiveCategoryCount();
        Task<int> TReceiveCategoryCount();

    }
}
