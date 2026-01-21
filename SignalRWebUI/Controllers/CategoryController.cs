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
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryViewModel categoryViewModel)
        {
            categoryViewModel.Status = true;

            var createCategoryDto = _mapper.Map<CreateCategoryDto>(categoryViewModel);
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
            var viewModel = _mapper.Map<CategoryViewModel>(value);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(int id, CategoryViewModel categoryViewModel)
        {

            categoryViewModel.Status = true;
            var dto = _mapper.Map<UpdateCategoryDto>(categoryViewModel);
            await _categoryApiService.UpdateAsync(id, dto);
            return RedirectToAction("CategoryList");
        }


    }
}
