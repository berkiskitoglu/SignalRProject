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
        public async Task<IActionResult> AddProductToBasket(CreateBasketProductDto createBasketProductDto)
        {
            var basketProduct = _mapper.Map<BasketProduct>(createBasketProductDto);
            await _basketProductService.TAddAsync(basketProduct);
            return Ok("Ürün sepete eklendi");
        }
    }
}
