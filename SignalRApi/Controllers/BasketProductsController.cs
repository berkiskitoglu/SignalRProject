using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDtos;
using SignalR.DtoLayer.BasketDtos;
using SignalR.DtoLayer.BasketProductDtos;
using SignalR.EntityLayer.Entities;
using System.Threading.Tasks;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketProductsController : ControllerBase
    {
        private readonly IBasketProductService _basketProductService;
        private readonly IMapper _mapper;

        public BasketProductsController(IBasketProductService basketProductService, IMapper mapper)
        {
            _basketProductService = basketProductService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasketProductsByBasketId(int id)
        {
            var result = await _basketProductService.TGetBasketProductsByBasketIdAsync(id);
            return Ok(_mapper.Map<List<ResultBasketProductDto>>(result));
        }


        [HttpPost]
        public async Task<IActionResult> AddProductToBasket(CreateBasketProductDto dto)
        {
            // 1️⃣ Sepetteki ürünleri al
            var basketProducts = await _basketProductService
                .TGetBasketProductsByBasketIdAsync(dto.BasketID);

            // 2️⃣ Aynı ürün var mı?
            var existingProduct = basketProducts
                .FirstOrDefault(x => x.ProductID == dto.ProductID);

            if (existingProduct != null)
            {
                // ✅ VAR → ADET ARTIR
                existingProduct.Quantity += dto.Quantity == 0 ? 1 : dto.Quantity;
                await _basketProductService.TUpdateAsync(existingProduct);
            }
            else
            {
                // ❌ YOK → YENİ EKLE
                var basketProduct = new BasketProduct
                {
                    BasketID = dto.BasketID,
                    ProductID = dto.ProductID,
                    Quantity = dto.Quantity == 0 ? 1 : dto.Quantity,
                    Price = dto.Price
                };

                await _basketProductService.TAddAsync(basketProduct);
            }

            return Ok("Ürün sepete eklendi");
        }
        [HttpDelete("{basketId}/{productId}")]
        public async Task<IActionResult> DeleteBasketProduct(int basketId, int productId)
        {
            var basketProduct =
                await _basketProductService.TGetByBasketAndProductIdAsync(basketId, productId);

            if (basketProduct == null)
                return NotFound("Ürün sepette bulunamadı");

            await _basketProductService.TDeleteAsync(basketProduct);
            return Ok("Ürün sepetten silindi");
        }



    }
}
