using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.Helpers.Dropdown;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;
using System.Threading.Tasks;

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
            return View(values);
        }

        [HttpGet]
        public  async Task<IActionResult> CreateProduct()
        {
            var viewModel = await _dropdownHelper.BuildProductViewModelAsync();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel productViewModel)
        {
            productViewModel.ProductStatus = true;
           var createProductDto = _mapper.Map<CreateProductDto>(productViewModel);
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
            var getProductById = await _productApiService.GetByIdAsync(id);
            var viewModel = _mapper.Map<ProductViewModel>(getProductById);
            viewModel.CategoryList = await _dropdownHelper.GetCategoryDropdownAsync();
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(int id , ProductViewModel productViewModel)
        {
            var dto = _mapper.Map<UpdateProductDto>(productViewModel);
            await _productApiService.UpdateAsync(id,dto);
            return RedirectToAction("ProductList");
        }

    }
}
