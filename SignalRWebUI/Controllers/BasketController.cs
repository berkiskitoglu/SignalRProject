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
        private readonly IBasketProductApiService _basketProductApiService;
        private readonly IMapper _mapper;

        public BasketController(IBasketApiService basketApiService, IMapper mapper, IBasketProductApiService basketProductApiService)
        {
            _basketApiService = basketApiService;
            _mapper = mapper;
            _basketProductApiService = basketProductApiService;
        }

        public async Task<IActionResult> Index(int id = 1)
        {

            var baskets = await _basketApiService.GetByIdAsync(id);
            var dto = _mapper.Map<IEnumerable<BasketViewModel>>(baskets);

            return View(dto);

        }
        public async Task<IActionResult> DeleteBasketProduct(int basketId,int productId)
        {
           await _basketProductApiService.DeleteBasketProduct(basketId,productId);
           return RedirectToAction("Index");
        }
      
   
    }
}
