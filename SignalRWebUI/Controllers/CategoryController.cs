using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels.CategoryViewModels;

namespace SignalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryApiService _categoryApiService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryApiService categoryApiService, IMapper mapper)
        {
            _categoryApiService = categoryApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> CategoryList()
        {
            List<ResultCategoryDto> values = await _categoryApiService.GetAllAsync();
            List<ResultCategoryViewModel> resultCategoryViewModels = _mapper.Map<List<ResultCategoryViewModel>>(values);
            return View(resultCategoryViewModels);
        }

        [HttpGet]
        public IActionResult CreateCategory() => View();

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {
            if (!ModelState.IsValid)
                return View(createCategoryViewModel);

            CreateCategoryDto createCategoryDto = _mapper.Map<CreateCategoryDto>(createCategoryViewModel);
            createCategoryDto.Status = true;
            await _categoryApiService.CreateAsync(createCategoryDto);
            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryApiService.DeleteAsync(id);
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            GetCategoryDto getCategoryDto = await _categoryApiService.GetByIdAsync(id);
            if (getCategoryDto is null) return NotFound();
            UpdateCategoryViewModel updateCategoryViewModel = _mapper.Map<UpdateCategoryViewModel>(getCategoryDto);
            return View(updateCategoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryViewModel updateCategoryViewModel)
        {
            if (!ModelState.IsValid)
                return View(updateCategoryViewModel);

            UpdateCategoryDto updateCategoryDto = _mapper.Map<UpdateCategoryDto>(updateCategoryViewModel);
            updateCategoryDto.Status = true;
            await _categoryApiService.UpdateAsync(id, updateCategoryDto);
            return RedirectToAction("CategoryList");
        }
    }
}