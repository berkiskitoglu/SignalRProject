using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDtos;
using SignalR.EntityLayer.Entities;
using SignalRApi.Hubs;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IHubContext<SignalRHub> _hubContext;
        private readonly IValidator<CreateCategoryDto> _createValidator;
        private readonly IValidator<UpdateCategoryDto> _updateValidator;

        public CategoriesController(
            ICategoryService categoryService,
            IMapper mapper,
            IHubContext<SignalRHub> hubContext,
            IValidator<CreateCategoryDto> createValidator,
            IValidator<UpdateCategoryDto> updateValidator)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _hubContext = hubContext;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
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
            var validationResult = await _createValidator.ValidateAsync(createCategoryDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

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
                return NotFound("Kategori bulunamadı");

            return Ok(_mapper.Map<ResultCategoryDto>(category));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateCategoryDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            var category = await _categoryService.TGetByIDAsync(id);
            if (category == null)
                return NotFound("Kategori bulunamadı");

            _mapper.Map(updateCategoryDto, category);
            await _categoryService.TUpdateAsync(category);
            return Ok("Kategori güncellendi");
        }
    }
}