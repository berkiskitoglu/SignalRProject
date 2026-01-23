using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal _moneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal MoneyCaseDal)
        {
            _moneyCaseDal = MoneyCaseDal;
        }

        public async Task TAddAsync(MoneyCase entity) => await _moneyCaseDal.AddAsync(entity);

        public async Task TUpdateAsync(MoneyCase entity) => await _moneyCaseDal.UpdateAsync(entity);

        public async Task TDeleteAsync(MoneyCase entity) => await _moneyCaseDal.DeleteAsync(entity);

        public async Task<MoneyCase?> TGetByIDAsync(int id) => await _moneyCaseDal.GetByIDAsync(id);

        public async Task<List<MoneyCase>> TGetListAllAsync() => await _moneyCaseDal.GetListAllAsync();

        public async Task<decimal> TTotalMoneyCaseAmount() => await _moneyCaseDal.TotalMoneyCaseAmount();

    }
}
