using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels.CategoryViewModel;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
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

            if(value is null) return NotFound();

            var viewModel = _mapper.Map<UpdateCategoryViewModel>(value);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryViewModel updateCategoryViewModel)
        {
      
            updateCategoryViewModel.Status = true;
            // AutoMapper ile ViewModel → DTO
            var dto = _mapper.Map<UpdateCategoryDto>(updateCategoryViewModel);

            // ID URL üzerinden gönderiliyor
            await _categoryApiService.UpdateAsync(id, dto);

            return RedirectToAction("CategoryList");
        }


    }
}
