using AutoMapper;
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

        public DiscountsController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountList()
            => Ok(_mapper.Map<List<ResultDiscountDto>>(await _discountService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            createDiscountDto.Status = false;
            var discount = _mapper.Map<Discount>(createDiscountDto);
            await _discountService.TAddAsync(discount);
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
                return NotFound();
            var dto = _mapper.Map<ResultDiscountDto>(discount);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiscount(int id, UpdateDiscountDto updateDiscountDto)
        {
            updateDiscountDto.Status = false;
            var discount = await _discountService.TGetByIDAsync(id);
            if (discount == null)
                return NotFound("İndirim bulunamadı");
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
        public  async Task<IActionResult> GetActiveDiscounts()
            => Ok(_mapper.Map<List<ResultDiscountDto>>(await _discountService.TGetAllActiveDiscounts())); 
    }
}