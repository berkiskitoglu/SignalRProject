using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class MenuTableManager : IMenuTableService
    {
        private readonly IMenuTableDal _menuTableDal;

        public MenuTableManager(IMenuTableDal menuTableDal)
        {
            _menuTableDal = menuTableDal;
        }

        public async Task TAddAsync(MenuTable entity) => await _menuTableDal.AddAsync(entity);

        public async Task TUpdateAsync(MenuTable entity) => await _menuTableDal.UpdateAsync(entity);

        public async Task TDeleteAsync(MenuTable entity) => await _menuTableDal.DeleteAsync(entity);

        public async Task<MenuTable?> TGetByIDAsync(int id) => await _menuTableDal.GetByIDAsync(id);

        public async Task<List<MenuTable>> TGetListAllAsync() => await _menuTableDal.GetListAllAsync();

        public async Task<int> TMenuTableCount() => await _menuTableDal.MenuTableCount();

    }
}
