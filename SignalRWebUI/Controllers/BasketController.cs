using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;
using System.Threading.Tasks;

namespace SignalRWebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketApiService _basketApiService;
        private readonly IMapper _mapper;

        public BasketController(IBasketApiService basketApiService, IMapper mapper)
        {
            _basketApiService = basketApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int id = 1)
        {

            var baskets = await _basketApiService.GetByIdAsync(id);
            var dto = _mapper.Map<IEnumerable<BasketViewModel>>(baskets);

            return View(dto);

        }
      
   
    }
}
