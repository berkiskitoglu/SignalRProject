using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDtos;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Entities;
using System.Threading.Tasks;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IBasketProductService _basketProductService;
        private readonly IMapper _mapper;

        public BasketsController(IBasketService basketService, IMapper mapper, IBasketProductService basketProductService)
        {
            _basketService = basketService;
            _mapper = mapper;
            _basketProductService = basketProductService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasketByMenuTableID(int id)
        {
            var basket = await _basketService.TGetBasketByMenuTableNumber(id);
            var dto = _mapper.Map<List<ResultBasketDto>>(basket);
            return Ok(dto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBaskets()
        {
            var baskets = await _basketService.TGetListAllAsync();
            var dto = _mapper.Map<List<ResultBasketDto>>(baskets);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket(CreateBasketDto createBasketDto)
        {
            try
            {
                // Basket'i oluştur
                var basket = _mapper.Map<Basket>(createBasketDto);
                await _basketService.TAddAsync(basket);

                // ✅ BasketProduct'ları kaydet
                if (createBasketDto.Products != null && createBasketDto.Products.Count > 0)
                {
                    foreach (var productDto in createBasketDto.Products)
                    {
                        productDto.BasketID = basket.BasketID;
                        var basketProduct = _mapper.Map<BasketProduct>(productDto);
                        await _basketProductService.TAddAsync(basketProduct);
                    }
                }

                return Ok(new { basketID = basket.BasketID, message = "Sepet oluşturuldu" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasket(int id)
        {
            var basket = await _basketService.TGetByIDAsync(id);
            if (basket == null)
            {
                return NotFound("Sepet bulunamadı");
            }
            await _basketService.TDeleteAsync(basket);
            return Ok("Sepet silindi");
        }

    }
}
