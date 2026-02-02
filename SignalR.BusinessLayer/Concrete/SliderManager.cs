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

        public async Task TAddAsync(Slider entity) => await _sliderDal.AddAsync(entity);


        public async Task TDeleteAsync(Slider entity) => await _sliderDal.DeleteAsync(entity);


        public async Task<Slider?> TGetByIDAsync(int id) => await _sliderDal.GetByIDAsync(id);


        public async Task<List<Slider>> TGetListAllAsync() => await _sliderDal.GetListAllAsync();
     

        public async Task TUpdateAsync(Slider entity) => await _sliderDal.UpdateAsync(entity);

    }
}
