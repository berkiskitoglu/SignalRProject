using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task TAddAsync(About entity) => await _aboutDal.AddAsync(entity);

        public async Task TUpdateAsync(About entity) => await _aboutDal.UpdateAsync(entity);

        public async Task TDeleteAsync(About entity) => await _aboutDal.DeleteAsync(entity);

        public async Task<About?> TGetByIDAsync(int id) => await _aboutDal.GetByIDAsync(id);

        public async Task<List<About>> TGetListAllAsync() => await _aboutDal.GetListAllAsync();
    }
}