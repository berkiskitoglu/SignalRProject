using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _createValidator;
        private readonly IValidator<UpdateBookingDto> _updateValidator;

        public BookingsController(
            IBookingService bookingService,
            IMapper mapper,
            IValidator<CreateBookingDto> createValidator,
            IValidator<UpdateBookingDto> updateValidator)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> BookingList()
            => Ok(_mapper.Map<List<ResultBookingDto>>(await _bookingService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            var validationResult = await _createValidator.ValidateAsync(createBookingDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            await _bookingService.TAddAsync(_mapper.Map<Booking>(createBookingDto));
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
            if (booking == null)
                return NotFound("Rezervasyon bulunamadı");

            return Ok(_mapper.Map<ResultBookingDto>(booking));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, UpdateBookingDto updateBookingDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateBookingDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            var booking = await _bookingService.TGetByIDAsync(id);
            if (booking == null)
                return NotFound("Rezervasyon bulunamadı");

            _mapper.Map(updateBookingDto, booking);
            await _bookingService.TUpdateAsync(booking);
            return Ok("Rezervasyon Bilgisi Güncellendi");
        }

        [HttpGet("BookingStatusApproved/{id}")]
        public async Task<IActionResult> BookingStatusApproved(int id)
        {
            await _bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon Açıklaması Onaylandı Olarak Güncellendi");
        }

        [HttpGet("BookingStatusCancelled/{id}")]
        public async Task<IActionResult> BookingStatusCancelled(int id)
        {
            await _bookingService.TBookingStatusCancelled(id);
            return Ok("Rezervasyon Açıklaması İptal Edildi Olarak Güncellendi");
        }
    }
}