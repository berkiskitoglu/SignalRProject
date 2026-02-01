using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.BookingDtos;
using SignalRWebUI.Services.Abstract;
using System.Threading.Tasks;

namespace SignalRWebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IBookingApiService _bookingApiService;

        public BookATableController(IBookingApiService bookingApiService)
        {
            _bookingApiService = bookingApiService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            await _bookingApiService.CreateAsync(createBookingDto);
            return RedirectToAction("Index", "Default");
        }
    }
}
