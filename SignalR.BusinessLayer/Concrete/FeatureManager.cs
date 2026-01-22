using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public async Task TAddAsync(Feature entity) => await _featureDal.AddAsync(entity);

        public async Task TDeleteAsync(Feature entity) => await _featureDal.DeleteAsync(entity);

        public async Task TUpdateAsync(Feature entity) => await _featureDal.UpdateAsync(entity);

        public async Task<Feature?> TGetByIDAsync(int id) => await _featureDal.GetByIDAsync(id);

        public async Task<List<Feature>> TGetListAllAsync() => await _featureDal.GetListAllAsync();
    }
}