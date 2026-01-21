using SignalRWebUI.Dtos.FeatureDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface IFeatureApiService : IGenericApiService<ResultFeatureDto,CreateFeatureDto,UpdateFeatureDto,GetFeatureDto>
    {
    }
}
