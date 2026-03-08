using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.DiscountDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels.DiscountViewModels;

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
            List<ResultDiscountDto> values = await _discountApiService.GetAllAsync();
            List<ResultDiscountViewModel> resultDiscountViewModels = _mapper.Map<List<ResultDiscountViewModel>>(values);
            return View(resultDiscountViewModels);
        }

        [HttpGet]
        public IActionResult CreateDiscount() => View();

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountViewModel createDiscountViewModel)
        {
            if (!ModelState.IsValid)
                return View(createDiscountViewModel);

            CreateDiscountDto createDiscountDto = _mapper.Map<CreateDiscountDto>(createDiscountViewModel);
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
            GetDiscountDto getDiscountDto = await _discountApiService.GetByIdAsync(id);
            if (getDiscountDto is null) return NotFound();
            UpdateDiscountViewModel updateDiscountViewModel = _mapper.Map<UpdateDiscountViewModel>(getDiscountDto);
            return View(updateDiscountViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(int id, UpdateDiscountViewModel updateDiscountViewModel)
        {
            if (!ModelState.IsValid)
                return View(updateDiscountViewModel);

            UpdateDiscountDto updateDiscountDto = _mapper.Map<UpdateDiscountDto>(updateDiscountViewModel);
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