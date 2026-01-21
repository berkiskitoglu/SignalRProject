using AutoMapper;
using SignalRWebUI.Dtos.FeatureDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<GetFeatureDto, FeatureViewModel>();
            CreateMap<FeatureViewModel, CreateFeatureDto>();
            CreateMap<FeatureViewModel, UpdateFeatureDto>();
        }
    }
}
