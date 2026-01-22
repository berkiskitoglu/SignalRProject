using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public async Task TAddAsync(Discount entity) => await _discountDal.AddAsync(entity);

        public async Task TDeleteAsync(Discount entity) => await _discountDal.DeleteAsync(entity);

        public async Task TUpdateAsync(Discount entity) => await _discountDal.UpdateAsync(entity);

        public async Task<Discount?> TGetByIDAsync(int id) => await _discountDal.GetByIDAsync(id);

        public async Task<List<Discount>> TGetListAllAsync() => await _discountDal.GetListAllAsync();
    }
}