using AutoMapper;
using SignalRWebUI.Dtos.BookingDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class BookingMapping : Profile
    {
        public BookingMapping()
        {
            CreateMap<GetBookingDto, BookingViewModel>();
            CreateMap<GetBookingDto, UpdateBookingDto>();
        }
    }
}
