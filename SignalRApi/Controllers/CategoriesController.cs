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
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var itemToDelete = _categoryService.TGetByID(id);
            _categoryService.TDelete(itemToDelete);
            return Ok("Kategori Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var getCategoryById = _categoryService.TGetByID(id);
            if (getCategoryById == null) return NotFound();
            return Ok(getCategoryById);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            if (updateCategoryDto == null)
                return BadRequest("Gönderilen veri boş");


            var category = _categoryService.TGetByID(id);

            if (category is null)
                return NotFound("Kategori bulunamadı");

            _mapper.Map(updateCategoryDto, category);

            _categoryService.TUpdate(category);

            return Ok("Kategori güncellendi");
        }

    }
}
