using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.BookingDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels.BookingViewModels;

namespace SignalRWebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IBookingApiService _bookingApiService;
        private readonly IMapper _mapper;

        public BookATableController(IBookingApiService bookingApiService, IMapper mapper)
        {
            _bookingApiService = bookingApiService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingViewModel createBookingViewModel)
        {
            if (!ModelState.IsValid)
                return View(createBookingViewModel);

            CreateBookingDto createBookingDto = _mapper.Map<CreateBookingDto>(createBookingViewModel);
            createBookingDto.Description = "Rezervasyon Alındı";
            await _bookingApiService.CreateAsync(createBookingDto);
            return RedirectToAction("Index", "Default");
        }
    }
}