using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.BasketDtos;
using System.Threading.Tasks;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketsController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
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
        [HttpGet("GetAllBasketsWithProducts")]
        public async Task<IActionResult> GetAllBasketsWithProducts()
        {
            var baskets = await _basketService.TGetAllBasketsWithProductsAsync();
            var result = _mapper.Map<List<ResultBasketDto>>(baskets);
            return Ok(result);
        }

    }
}
