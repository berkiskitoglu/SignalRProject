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

        public ProductsController(IProductService ProductService, IMapper mapper)
        {
            _productService = ProductService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var productList = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(productList);
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var productListWithCategory = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());
            return Ok(productListWithCategory);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(product);
            return Ok("Ürün Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var itemToDelete = _productService.TGetByID(id);
            _productService.TDelete(itemToDelete);
            return Ok("Ürün Silindi");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var getProductById = _productService.TGetByID(id);
            return Ok(getProductById);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var product = _productService.TGetByID(updateProductDto.ProductID);
            if (product == null)
            {
                return NotFound("Ürün bulunamadı");
            }
            _mapper.Map(updateProductDto, product);
            _productService.TUpdate(product);
            return Ok("Ürün Güncellendi");
        }
    }
}
