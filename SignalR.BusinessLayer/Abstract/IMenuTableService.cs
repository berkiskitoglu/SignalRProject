using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IMenuTableService : IGenericService<MenuTable>
    {
        Task<int> TMenuTableCount();
        Task TChangeMenuTableStatusToTrue(int id);
        Task TChangeMenuTableStatusToFalse(int id);
    }
}
