using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public async Task TAddAsync(Testimonial entity) => await _testimonialDal.AddAsync(entity);

        public async Task TDeleteAsync(Testimonial entity) => await _testimonialDal.DeleteAsync(entity);

        public async Task TUpdateAsync(Testimonial entity) => await _testimonialDal.UpdateAsync(entity);

        public async Task<Testimonial?> TGetByIDAsync(int id) => await _testimonialDal.GetByIDAsync(id);

        public async Task<List<Testimonial>> TGetListAllAsync() => await _testimonialDal.GetListAllAsync();
    }
}