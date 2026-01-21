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
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var itemToDelete = _productService.TGetByID(id);
            _productService.TDelete(itemToDelete);
            return Ok("Ürün Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.TGetByID(id);
            if (product == null)
                return NotFound();

            var dto = _mapper.Map<ResultProductDto>(product);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id ,UpdateProductDto updateProductDto)
        {
            var product = _productService.TGetByID(id);
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
