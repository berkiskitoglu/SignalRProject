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

        public Task TAddAsync(Basket entity)
        {
            throw new NotImplementedException();
        }

        public Task TDeleteAsync(Basket entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Basket>> TGetAllBasketsWithProductsAsync() => await _basketDal.GetAllBasketsWithProductsAsync();


        public async Task<List<Basket>> TGetBasketByMenuTableNumber(int id) => await _basketDal.GetBasketByMenuTableNumber(id);

        public Task<Basket?> TGetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Basket>> TGetListAllAsync() => await _basketDal.GetListAllAsync();


        public Task TUpdateAsync(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}
