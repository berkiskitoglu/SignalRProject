using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDtos;
using SignalR.EntityLayer.Entities;
using SignalRApi.Hubs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IHubContext<SignalRHub> _hubContext;
        public CategoriesController(ICategoryService categoryService, IMapper mapper, IHubContext<SignalRHub> hubContext)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
            => Ok(_mapper.Map<List<ResultCategoryDto>>(await _categoryService.TGetListAllAsync()));

        [HttpGet("CategoryCount")]
        public async Task<IActionResult> CategoryCount()
            => Ok(await _categoryService.TCategoryCountAsync());

        [HttpGet("ActiveCategoryCount")]
        public async Task<IActionResult> ActiveCategoryCount()
            => Ok(await _categoryService.TActiveCategoryCount());

        [HttpGet("PassiveCategoryCount")]
        public async Task<IActionResult> PassiveCategoryCount()
            => Ok(await _categoryService.TPassiveCategoryCount());

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            category.Status = true;
            await _categoryService.TAddAsync(category);   
            return Ok("Kategori Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var itemToDelete = await _categoryService.TGetByIDAsync(id);
            if (itemToDelete == null)
                return NotFound("Kategori bulunamadı");
            await _categoryService.TDeleteAsync(itemToDelete);
            return Ok("Kategori Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.TGetByIDAsync(id);
            if (category == null)
                return NotFound();
            var dto = _mapper.Map<ResultCategoryDto>(category);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            var category = await _categoryService.TGetByIDAsync(id);
            if (category == null)
                return NotFound("Kategori bulunamadı");
            _mapper.Map(updateCategoryDto, category);
            await _categoryService.TUpdateAsync(category);
            return Ok("Kategori güncellendi");
        }
    }
}