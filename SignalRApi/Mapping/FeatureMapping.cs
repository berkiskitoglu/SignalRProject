using AutoMapper;
using SignalR.DtoLayer.FeatureDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, ResultFeatureDto>();
            CreateMap<Feature, GetFeatureDto>();

            CreateMap<CreateFeatureDto, Feature>();
            CreateMap<UpdateFeatureDto, Feature>();
        }
    }
}
