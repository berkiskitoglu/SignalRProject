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
        private readonly IMenuTableApiService _menuTableApiService;

        public MenuController(IProductApiService productApiService, IBasketApiService basketApiService, IMenuTableApiService menuTableApiService)
        {
            _productApiService = productApiService;
            _basketApiService = basketApiService;
            _menuTableApiService = menuTableApiService;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id;
            var values = await _productApiService.GetProductsWithCategoryAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int id, int menuTableId)
        {
            var product = await _productApiService.GetByIdAsync(id);
            if (product == null)
                return BadRequest("Ürün bulunamadı");

            var createBasketDto = new CreateBasketDto
            {
                MenuTableID = menuTableId,
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
            await _menuTableApiService.TChangeMenuTableStatusToTrue(menuTableId);
            await _basketApiService.CreateAsync(createBasketDto);
            return Ok();
        }
    }
}