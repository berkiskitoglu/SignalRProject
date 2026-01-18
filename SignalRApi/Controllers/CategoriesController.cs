using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var categoryList = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(categoryList);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            category.Status = true;
            _categoryService.TAdd(category);
            return Ok("Kategori Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var itemToDelete = _categoryService.TGetByID(id);
            _categoryService.TDelete(itemToDelete);
            return Ok("Kategori Silindi");
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var getCategoryById = _categoryService.TGetByID(id);
            return Ok(getCategoryById);
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = _categoryService.TGetByID(updateCategoryDto.CategoryID);
            if(category == null)
            {
                return NotFound("Kategori bulunamadı");
            }
            _mapper.Map(updateCategoryDto, category);
            _categoryService.TUpdate(category);
            return Ok("Kategori Güncellendi");
        }
    }
}
