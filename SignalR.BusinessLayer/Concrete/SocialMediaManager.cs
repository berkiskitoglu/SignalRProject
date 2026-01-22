using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public async Task TAddAsync(SocialMedia entity) => await _socialMediaDal.AddAsync(entity);

        public async Task TDeleteAsync(SocialMedia entity) => await _socialMediaDal.DeleteAsync(entity);

        public async Task TUpdateAsync(SocialMedia entity) => await _socialMediaDal.UpdateAsync(entity);

        public async Task<SocialMedia?> TGetByIDAsync(int id) => await _socialMediaDal.GetByIDAsync(id);

        public async Task<List<SocialMedia>> TGetListAllAsync() => await _socialMediaDal.GetListAllAsync();
    }
}