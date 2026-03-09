using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BasketProductDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketProductsController : ControllerBase
    {
        private readonly IBasketProductService _basketProductService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBasketProductDto> _createValidator;

        public BasketProductsController(
            IBasketProductService basketProductService,
            IMapper mapper,
            IValidator<CreateBasketProductDto> createValidator)
        {
            _basketProductService = basketProductService;
            _mapper = mapper;
            _createValidator = createValidator;
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
      
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            var basketProducts = await _basketProductService
                .TGetBasketProductsByBasketIdAsync(dto.BasketID);

            var existingProduct = basketProducts
                .FirstOrDefault(x => x.ProductID == dto.ProductID);

            if (existingProduct != null)
            {
                existingProduct.Quantity += dto.Quantity == 0 ? 1 : dto.Quantity;
                await _basketProductService.TUpdateAsync(existingProduct);
            }
            else
            {
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