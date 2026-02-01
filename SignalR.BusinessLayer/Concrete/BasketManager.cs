using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public async Task TAddAsync(Basket entity)
        {
            await _basketDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Basket entity)
        {
            await _basketDal.DeleteAsync(entity);
        }

        public async Task<List<Basket>> TGetBasketByMenuTableNumber(int id) => await _basketDal.GetBasketByMenuTableNumber(id);

        public async Task<Basket?> TGetByIDAsync(int id)
        {
            return await _basketDal.GetByIDAsync(id);
        }

        public async Task<List<Basket>> TGetListAllAsync() => await _basketDal.GetListAllAsync();


        public Task TUpdateAsync(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}
