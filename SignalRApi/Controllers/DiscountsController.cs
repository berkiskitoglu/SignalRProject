using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            var discount = await _discountService.TGetByIDAsync(id);
            if (discount == null)
                return NotFound("İndirim bulunamadı");
            _mapper.Map(updateDiscountDto, discount);
            await _discountService.TUpdateAsync(discount);
            return Ok("İndirim Güncellendi");
        }
    }
}