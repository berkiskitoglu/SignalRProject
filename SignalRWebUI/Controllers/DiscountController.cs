using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.DiscountDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountApiService _discountApiService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountApiService discountApiService, IMapper mapper)
        {
            _discountApiService = discountApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> DiscountList()
        {
            var values = await _discountApiService.GetAllAsync();
            var viewModels = _mapper.Map<List<DiscountViewModel>>(values);
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult CreateDiscount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            if (!ModelState.IsValid)
                return View(createDiscountDto);

            await _discountApiService.CreateAsync(createDiscountDto);
            return RedirectToAction("DiscountList");
        }

        public async Task<IActionResult> DeleteDiscount(int id)
        {
            await _discountApiService.DeleteAsync(id);
            return RedirectToAction("DiscountList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(int id)
        {
            var value = await _discountApiService.GetByIdAsync(id);
            if (value is null) return NotFound();
            var dto = _mapper.Map<UpdateDiscountDto>(value);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(int id, UpdateDiscountDto updateDiscountDto)
        {
            if (!ModelState.IsValid)
                return View(updateDiscountDto);

            await _discountApiService.UpdateAsync(id, updateDiscountDto);
            return RedirectToAction("DiscountList");
        }

        public async Task<IActionResult> ChangeStatusToFalse(int id)
        {
            await _discountApiService.ChangeStatusToFalse(id);
            return RedirectToAction("DiscountList");
        }

        public async Task<IActionResult> ChangeStatusToTrue(int id)
        {
            await _discountApiService.ChangeStatusToTrue(id);
            return RedirectToAction("DiscountList");
        }
    }
}