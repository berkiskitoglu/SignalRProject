using AutoMapper;
using SignalR.DtoLayer.DiscountDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class DiscountMapping : Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount, ResultDiscountDto>();
            CreateMap<Discount, GetDiscountDto>();

            CreateMap<CreateDiscountDto, Discount>();
            CreateMap<UpdateDiscountDto, Discount>();
        }
    }
}
