using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.Helpers.Dropdown;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

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
            var values = await _productApiService.GetProductsWithCategoryAsync();
            var viewModel = new ProductListViewModel
            {
                Products = values.ToList(),
                Categories = values.Select(x => x.CategoryName).Distinct().ToList()
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var viewModel = await _dropdownHelper.BuildProductViewModelAsync();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                productViewModel.CategoryList = await _dropdownHelper.GetCategoryDropdownAsync();
                return View(productViewModel);
            }
            var createProductDto = _mapper.Map<CreateProductDto>(productViewModel);
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
            var value = await _productApiService.GetByIdAsync(id);
            if (value is null) return NotFound();
            var viewModel = _mapper.Map<ProductViewModel>(value);
            viewModel.CategoryList = await _dropdownHelper.GetCategoryDropdownAsync();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(int id, ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                productViewModel.CategoryList = await _dropdownHelper.GetCategoryDropdownAsync();
                return View(productViewModel);
            }
            var dto = _mapper.Map<UpdateProductDto>(productViewModel);
            await _productApiService.UpdateAsync(id, dto);
            return RedirectToAction("ProductList");
        }
    }
}