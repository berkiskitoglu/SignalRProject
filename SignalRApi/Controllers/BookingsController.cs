using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDtos;
using SignalR.EntityLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> BookingList()
            => Ok(_mapper.Map<List<ResultBookingDto>>(await _bookingService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            var booking = _mapper.Map<Booking>(createBookingDto);
            await _bookingService.TAddAsync(booking);
            return Ok("Rezervasyon Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var itemToDelete = await _bookingService.TGetByIDAsync(id);
            if (itemToDelete == null)
                return NotFound("Rezervasyon bulunamadı");
            await _bookingService.TDeleteAsync(itemToDelete);
            return Ok("Rezervasyon Bilgisi Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var booking = await _bookingService.TGetByIDAsync(id);
            var dto = _mapper.Map<ResultBookingDto>(booking);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, UpdateBookingDto updateBookingDto)
        {
            var booking = await _bookingService.TGetByIDAsync(id);
            if (booking == null)
                return NotFound("Rezervasyon bulunamadı");
            _mapper.Map(updateBookingDto, booking);
            await _bookingService.TUpdateAsync(booking);
            return Ok("Rezervasyon Bilgisi Güncellendi");
        }
    }
}