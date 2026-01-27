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
    public class BasketProductManager : IBasketProductService
    {
        private readonly IBasketProductDal _basketProductDal;

        public BasketProductManager(IBasketProductDal basketProductDal)
        {
            _basketProductDal = basketProductDal;
        }

        public async Task TAddAsync(BasketProduct entity)
        {
            await _basketProductDal.AddAsync(entity);
        }

        public Task TDeleteAsync(BasketProduct entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BasketProduct>> TGetBasketProductsByBasketIdAsync(int basketId)
        {
            return await _basketProductDal.GetBasketProductsByBasketIdAsync(basketId);
        }

        public async Task<BasketProduct?> TGetByIDAsync(int id)
        {
           return  await _basketProductDal.GetByIDAsync(id);
        }

        public Task<List<BasketProduct>> TGetListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task TUpdateAsync(BasketProduct entity)
        {
            throw new NotImplementedException();
        }
    }
}
