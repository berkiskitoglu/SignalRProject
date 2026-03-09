using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IBasketProductService _basketProductService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBasketDto> _createValidator;

        public BasketsController(
            IBasketService basketService,
            IMapper mapper,
            IBasketProductService basketProductService,
            IValidator<CreateBasketDto> createValidator)
        {
            _basketService = basketService;
            _mapper = mapper;
            _basketProductService = basketProductService;
            _createValidator = createValidator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasketByMenuTableID(int id)
        {
            var basket = await _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(_mapper.Map<List<ResultBasketDto>>(basket));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBaskets()
        {
            var baskets = await _basketService.TGetListAllAsync();
            return Ok(_mapper.Map<List<ResultBasketDto>>(baskets));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket(CreateBasketDto createBasketDto)
        {
            var validationResult = await _createValidator.ValidateAsync(createBasketDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            try
            {
                var basket = _mapper.Map<Basket>(createBasketDto);
                await _basketService.TAddAsync(basket);

                if (createBasketDto.Products != null && createBasketDto.Products.Count > 0)
                {
                    foreach (var productDto in createBasketDto.Products)
                    {
                        productDto.BasketID = basket.BasketID;
                     
                        await _basketProductService.TAddAsync(_mapper.Map<BasketProduct>(productDto));
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
                return NotFound("Sepet bulunamadı");

            await _basketService.TDeleteAsync(basket);
            return Ok("Sepet silindi");
        }
    }
}