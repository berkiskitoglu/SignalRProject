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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public Task TAddAsync(Slider entity)
        {
            throw new NotImplementedException();
        }

        public Task TDeleteAsync(Slider entity)
        {
            throw new NotImplementedException();
        }

        public Task<Slider?> TGetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Slider>> TGetListAllAsync() => await _sliderDal.GetListAllAsync();
     

        public Task TUpdateAsync(Slider entity)
        {
            throw new NotImplementedException();
        }
    }
}
