using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        Task<int> CategoryCountAsync();
        Task<int> ActiveCategoryCount();
        Task<int> PassiveCategoryCount();
        Task<int> ReceiveCategoryCount();
    }
}
