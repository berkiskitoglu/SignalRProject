using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingService BookingService, IMapper mapper)
        {
            _bookingService = BookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var bookingList = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
            return Ok(bookingList);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var booking = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var itemToDelete = _bookingService.TGetByID(id);
            _bookingService.TDelete(itemToDelete);
            return Ok("Rezervasyon Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var booking = _bookingService.TGetByID(id);
            if (booking == null)
                return NotFound();

            var dto = _mapper.Map<ResultBookingDto>(booking);
            return Ok(dto);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBooking(int id , UpdateBookingDto updateBookingDto)
        {
            var booking = _bookingService.TGetByID(id);
            if (booking is null)
                return NotFound("Kategori Bulunamadı");
            _mapper.Map(updateBookingDto, booking);
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon Bilgisi Güncellendi");
        }
    }
}
