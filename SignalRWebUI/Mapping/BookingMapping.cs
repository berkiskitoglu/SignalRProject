using AutoMapper;
using SignalRWebUI.Dtos.BookingDtos;
using SignalRWebUI.ViewModels.BookingViewModels;

namespace SignalRWebUI.Mapping
{
    public class BookingMapping : Profile
    {
        public BookingMapping()
        {
            CreateMap<ResultBookingDto, ResultBookingViewModel>();
            CreateMap<GetBookingDto, UpdateBookingViewModel>();
            CreateMap<CreateBookingViewModel, CreateBookingDto>();
            CreateMap<UpdateBookingViewModel, UpdateBookingDto>();
        }
    }
}