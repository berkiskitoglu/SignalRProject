using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task TAddAsync(Contact entity) => await _contactDal.AddAsync(entity);

        public async Task TDeleteAsync(Contact entity) => await _contactDal.DeleteAsync(entity);

        public async Task TUpdateAsync(Contact entity) => await _contactDal.UpdateAsync(entity);

        public async Task<Contact?> TGetByIDAsync(int id) => await _contactDal.GetByIDAsync(id);

        public async Task<List<Contact>> TGetListAllAsync() => await _contactDal.GetListAllAsync();
    }
}