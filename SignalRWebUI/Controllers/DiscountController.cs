using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.DiscountDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountApiService _DiscountApiService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountApiService DiscountApiService, IMapper mapper)
        {
            _DiscountApiService = DiscountApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> DiscountList()
        {
            var values = await _DiscountApiService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateDiscount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(DiscountViewModel DiscountViewModel)
        {

            var createDiscountDto = _mapper.Map<CreateDiscountDto>(DiscountViewModel);
            await _DiscountApiService.CreateAsync(createDiscountDto);
            return RedirectToAction("DiscountList");
        }

        public async Task<IActionResult> DeleteDiscount(int id)
        {

            await _DiscountApiService.DeleteAsync(id);
            return RedirectToAction("DiscountList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(int id)
        {
            var value = await _DiscountApiService.GetByIdAsync(id);
            var viewModel = _mapper.Map<DiscountViewModel>(value);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(int id, DiscountViewModel DiscountViewModel)
        {

            var dto = _mapper.Map<UpdateDiscountDto>(DiscountViewModel);
            await _DiscountApiService.UpdateAsync(id, dto);
            return RedirectToAction("DiscountList");
        }
    }
}
