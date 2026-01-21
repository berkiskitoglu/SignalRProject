using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.FeatureDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureApiService _FeatureApiService;
        private readonly IMapper _mapper;



        public FeatureController(IFeatureApiService FeatureApiService, IMapper mapper)
        {
            _FeatureApiService = FeatureApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> FeatureList()
        {
            var values = await _FeatureApiService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(FeatureViewModel FeatureViewModel)
        {

            var createFeatureDto = _mapper.Map<CreateFeatureDto>(FeatureViewModel);
            await _FeatureApiService.CreateAsync(createFeatureDto);
            return RedirectToAction("FeatureList");
        }

        public async Task<IActionResult> DeleteFeature(int id)
        {

            await _FeatureApiService.DeleteAsync(id);
            return RedirectToAction("FeatureList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var value = await _FeatureApiService.GetByIdAsync(id);
            var viewModel = _mapper.Map<FeatureViewModel>(value);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(int id, FeatureViewModel FeatureViewModel)
        {

            var dto = _mapper.Map<UpdateFeatureDto>(FeatureViewModel);
            await _FeatureApiService.UpdateAsync(id, dto);
            return RedirectToAction("FeatureList");
        }
    }
}
