using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDiscountDto> _createValidator;
        private readonly IValidator<UpdateDiscountDto> _updateValidator;

        public DiscountsController(
            IDiscountService discountService,
            IMapper mapper,
            IValidator<CreateDiscountDto> createValidator,
            IValidator<UpdateDiscountDto> updateValidator)
        {
            _discountService = discountService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountList()
            => Ok(_mapper.Map<List<ResultDiscountDto>>(await _discountService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var validationResult = await _createValidator.ValidateAsync(createDiscountDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            createDiscountDto.Status = false;
            await _discountService.TAddAsync(_mapper.Map<Discount>(createDiscountDto));
            return Ok("İndirim Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var itemToDelete = await _discountService.TGetByIDAsync(id);
            if (itemToDelete == null)
                return NotFound("İndirim bulunamadı");

            await _discountService.TDeleteAsync(itemToDelete);
            return Ok("İndirim Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscount(int id)
        {
            var discount = await _discountService.TGetByIDAsync(id);
            if (discount == null)
                return NotFound("İndirim bulunamadı");

            return Ok(_mapper.Map<ResultDiscountDto>(discount));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiscount(int id, UpdateDiscountDto updateDiscountDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateDiscountDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            var discount = await _discountService.TGetByIDAsync(id);
            if (discount == null)
                return NotFound("İndirim bulunamadı");

            updateDiscountDto.Status = false;
            _mapper.Map(updateDiscountDto, discount);
            await _discountService.TUpdateAsync(discount);
            return Ok("İndirim Güncellendi");
        }

        [HttpGet("ChangeStatusToTrue/{id}")]
        public async Task<IActionResult> ChangeStatusToTrue(int id)
        {
            await _discountService.TChangeStatusToTrue(id);
            return Ok("İndirim Aktif Hale Getirildi");
        }

        [HttpGet("ChangeStatusToFalse/{id}")]
        public async Task<IActionResult> ChangeStatusToFalse(int id)
        {
            await _discountService.TChangeStatusToFalse(id);
            return Ok("İndirim Pasif Hale Getirildi");
        }

        [HttpGet("GetActiveDiscounts")]
        public async Task<IActionResult> GetActiveDiscounts()
            => Ok(_mapper.Map<List<ResultDiscountDto>>(await _discountService.TGetAllActiveDiscounts()));
    }
}