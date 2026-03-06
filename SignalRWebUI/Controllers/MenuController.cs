using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.BasketProductDtos;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IProductApiService _productApiService;
        private readonly IBasketApiService _basketApiService;

        public MenuController(IProductApiService productApiService, IBasketApiService basketApiService)
        {
            _productApiService = productApiService;
            _basketApiService = basketApiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productApiService.GetAllAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);
            if (product == null)
                return BadRequest("Ürün bulunamadı");

            var createBasketDto = new CreateBasketDto
            {
                MenuTableID = 1,
                Status = "Aktif",
                Products = new List<CreateBasketProductDto>
        {
            new CreateBasketProductDto
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Price = product.Price,
                Quantity = 1
            }
        }
            };

            await _basketApiService.CreateAsync(createBasketDto);
            return Ok();
        }
    }
}