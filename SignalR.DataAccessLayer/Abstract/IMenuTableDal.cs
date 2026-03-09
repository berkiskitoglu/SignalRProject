using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IMenuTableDal : IGenericDal<MenuTable>
    {
        Task<int> MenuTableCount();
        Task ChangeMenuTableStatusToTrue(int id);
        Task ChangeMenuTableStatusToFalse(int id);
    }
}