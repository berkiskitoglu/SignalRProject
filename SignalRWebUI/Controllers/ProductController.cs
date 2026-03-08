using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.Helpers.Dropdown;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels.ProductViewModels;

namespace SignalRWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductApiService _productApiService;
        private readonly ICategoryApiService _categoryApiService;
        private readonly IDropdownHelper _dropdownHelper;

        public ProductController(IProductApiService productApiService, ICategoryApiService categoryApiService, IMapper mapper, IDropdownHelper dropdownHelper)
        {
            _productApiService = productApiService;
            _categoryApiService = categoryApiService;
            _mapper = mapper;
            _dropdownHelper = dropdownHelper;
        }

        public async Task<IActionResult> ProductList()
        {
            List<ResultProductWithCategoryDto> values = await _productApiService.GetProductsWithCategoryAsync();
            List<ResultProductViewModel> resultProductViewModels = _mapper.Map<List<ResultProductViewModel>>(values);

            ProductListViewModel productListViewModel = new ProductListViewModel
            {
                Products = resultProductViewModels,
                Categories = resultProductViewModels.Select(x => x.CategoryName).Distinct().ToList()
            };

            return View(productListViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            CreateProductViewModel createProductViewModel = await _dropdownHelper.BuildCreateProductViewModelAsync();
            return View(createProductViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel createProductViewModel)
        {
            if (!ModelState.IsValid)
            {
                createProductViewModel.CategoryList = await _dropdownHelper.GetCategoryDropdownAsync();
                return View(createProductViewModel);
            }

            CreateProductDto createProductDto = _mapper.Map<CreateProductDto>(createProductViewModel);
            createProductDto.ProductStatus = true;
            await _productApiService.CreateAsync(createProductDto);
            return RedirectToAction("ProductList");
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productApiService.DeleteAsync(id);
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            GetProductDto getProductDto = await _productApiService.GetByIdAsync(id);
            if (getProductDto is null) return NotFound();

            UpdateProductViewModel updateProductViewModel = _mapper.Map<UpdateProductViewModel>(getProductDto);
            updateProductViewModel.CategoryList = await _dropdownHelper.GetCategoryDropdownAsync();

            return View(updateProductViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductViewModel updateProductViewModel)
        {
            if (!ModelState.IsValid)
            {
                updateProductViewModel.CategoryList = await _dropdownHelper.GetCategoryDropdownAsync();
                return View(updateProductViewModel);
            }

            UpdateProductDto updateProductDto = _mapper.Map<UpdateProductDto>(updateProductViewModel);
            await _productApiService.UpdateAsync(id, updateProductDto);
            return RedirectToAction("ProductList");
        }
    }
}