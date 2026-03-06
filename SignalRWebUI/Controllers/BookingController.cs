using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.BookingDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingApiService _bookingApiService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public BookingController(IBookingApiService bookingApiService, IMapper mapper, IConfiguration configuration)
        {
            _bookingApiService = bookingApiService;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IActionResult> BookingList()
        {
            ViewBag.HubUrl = _configuration["ApiSettings:BaseUrl"] + "SignalRHub";
            return View();
        }

        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            if (!ModelState.IsValid)
                return View(createBookingDto);

            createBookingDto.Description = "Rezervasyon Alındı";
            await _bookingApiService.CreateAsync(createBookingDto);
            return RedirectToAction("BookingList");
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingApiService.DeleteAsync(id);
            return RedirectToAction("BookingList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var value = await _bookingApiService.GetByIdAsync(id);
            if (value is null) return NotFound();
            var dto = _mapper.Map<UpdateBookingDto>(value);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(int id, UpdateBookingDto updateBookingDto)
        {
            if (!ModelState.IsValid)
                return View(updateBookingDto);
            updateBookingDto.Description = "Rezervasyon Alındı";
            await _bookingApiService.UpdateAsync(id, updateBookingDto);
            return RedirectToAction("BookingList");
        }

        public async Task<IActionResult> BookingStatusApproved(int id)
        {
            await _bookingApiService.BookingStatusApproved(id);
            return RedirectToAction("BookingList");
        }

        public async Task<IActionResult> BookingStatusCancelled(int id)
        {
            await _bookingApiService.BookingStatusCancelled(id);
            return RedirectToAction("BookingList");
        }
    }
}