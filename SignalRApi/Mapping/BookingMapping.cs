using AutoMapper;
using SignalR.DtoLayer.BookingDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class BookingMapping : Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking, ResultBookingDto>();
            CreateMap<Booking, GetBookingDto>();

            CreateMap<CreateBookingDto, Booking>();
            CreateMap<UpdateBookingDto, Booking>();
        }
    }
}
