using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService categoryService, IMapper mapper)
        {
            _productService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ProductList()       
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
           return Ok(_productService.TProductCount());
        }
        [HttpGet("ProductCountByHamburger")]
        public IActionResult ProductCountByHamburger()
        {
            return Ok(_productService.TProductCountByCategoryNameHamburger());
        }
        [HttpGet("ProductCountByDrink")]
        public IActionResult ProductCountByDrink()
        {
            return Ok(_productService.TProductCountByCategoryNameDrink());
        }
        [HttpGet("AveragePriceOfProducts")]
        public IActionResult AveragePriceOfProducts()
        {
            return Ok(_productService.TAveragePriceOfProducts());
        }
        [HttpGet("MaxPriceOfProducts")]
        public IActionResult MaxPriceOfProducts()
        {
            return Ok(_productService.TMaxPriceProductName());
        }
        [HttpGet("MinPriceOfProducts")]
        public IActionResult MinPriceOfProducts()
        {
            return Ok(_productService.TMinPriceProductName());
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var value = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());
            return Ok(value);
        }
        [HttpGet("AverageProductPriceOfHamburger")]
        public IActionResult AverageProductPriceOfHamburger()
        {
            return Ok(_productService.TAverageProductPriceOfHamburger());
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product
            {
               Description = createProductDto.Description,
               ImageUrl = createProductDto.ImageUrl,
               Price = createProductDto.Price,
               ProductName = createProductDto.ProductName,
               ProductStatus = createProductDto.ProductStatus,
               CategoryID = createProductDto.CategoryID
               
            });
            return Ok("Ürün Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Ürün Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product
            {
                ProductID = updateProductDto.ProductID,
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                Price = updateProductDto.Price,
                ProductName = updateProductDto.ProductName,
                ProductStatus = updateProductDto.ProductStatus,
                CategoryID = updateProductDto.CategoryID
            });
            return Ok("Ürün Bilgisi Güncellendi");
        }

    }
}
