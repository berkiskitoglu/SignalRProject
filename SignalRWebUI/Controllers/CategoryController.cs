using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

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
            var values = await _categoryApiService.GetAllAsync();
            var viewModels = _mapper.Map<List<CategoryViewModel>>(values);
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
                return View(createCategoryDto);

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
            var value = await _categoryApiService.GetByIdAsync(id);
            if (value is null) return NotFound();
            var dto = _mapper.Map<UpdateCategoryDto>(value);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            if (!ModelState.IsValid)
                return View(updateCategoryDto);

            updateCategoryDto.Status = true;
            await _categoryApiService.UpdateAsync(id, updateCategoryDto);
            return RedirectToAction("CategoryList");
        }
    }
}