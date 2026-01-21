using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.BookingDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingApiService _BookingApiService;
        private readonly IMapper _mapper;

        public BookingController(IBookingApiService BookingApiService, IMapper mapper)
        {
            _BookingApiService = BookingApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> BookingList()
        {
            var values = await _BookingApiService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingViewModel BookingViewModel)
        {

            var createBookingDto = _mapper.Map<CreateBookingDto>(BookingViewModel);
            await _BookingApiService.CreateAsync(createBookingDto);
            return RedirectToAction("BookingList");
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {

            await _BookingApiService.DeleteAsync(id);
            return RedirectToAction("BookingList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var value = await _BookingApiService.GetByIdAsync(id);
            var viewModel = _mapper.Map<BookingViewModel>(value);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(int id, BookingViewModel BookingViewModel)
        {

            var dto = _mapper.Map<UpdateBookingDto>(BookingViewModel);
            await _BookingApiService.UpdateAsync(id, dto);
            return RedirectToAction("BookingList");
        }
    }
}
