using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountsController(IDiscountService DiscountService, IMapper mapper)
        {
            _discountService = DiscountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var discountList = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(discountList);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var discount = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(discount);
            return Ok("İndirim Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var itemToDelete = _discountService.TGetByID(id);
            _discountService.TDelete(itemToDelete);
            return Ok("İndirim Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var discount = _discountService.TGetByID(id);
            if (discount == null)
                return NotFound();

            var dto = _mapper.Map<ResultDiscountDto>(discount);
            return Ok(dto);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateDiscount(int id , UpdateDiscountDto updateDiscountDto)
        {
            var discount = _discountService.TGetByID(id);
            if (discount == null)
            {
                return NotFound("İndirim bulunamadı");
            }
            _mapper.Map(updateDiscountDto, discount);
            _discountService.TUpdate(discount);
            return Ok("İndirim Güncellendi");
        }
    }
}
