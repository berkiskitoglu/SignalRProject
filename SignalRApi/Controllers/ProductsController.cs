using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDtos;
using SignalR.EntityLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList() => Ok(_mapper.Map<List<ResultProductDto>>(await _productService.TGetListAllAsync()));

        [HttpGet("ProductCount")]
        public async Task<IActionResult> ProductCount() => Ok(await _productService.TProductCount());

        [HttpGet("ProductCountByDrink")]
        public async Task<IActionResult> ProductCountByDrink() => Ok(await _productService.TProductCountByCategoryNameDrink());

        [HttpGet("ProductCountByHamburger")]
        public async Task<IActionResult> ProductCountByHamburger() => Ok(await _productService.TProductCountByCategoryNameHamburger());

        [HttpGet("ProductNameByMaxPrice")]
        public async Task<IActionResult> ProductNameByMaxPrice() => Ok(await _productService.TProductNameByMaxPrice());

        [HttpGet("ProductNameByMinPrice")]
        public async Task<IActionResult> ProductNameByMinPrice() => Ok(await _productService.TProductNameByMinPrice());

        [HttpGet("ProductPriceAverage")]
        public async Task<IActionResult> ProductPriceAverage() => Ok(await _productService.TProductPriceAverage());

        [HttpGet("AverageProductPriceHamburger")]
        public async Task<IActionResult> AverageProductPriceHamburger() => Ok(await _productService.TAverageProductPriceHamburger());

        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory() => Ok(_mapper.Map<List<ResultProductWithCategory>>(await _productService.TGetProductsWithCategoriesAsync()));



        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            await _productService.TAddAsync(product);
            return Ok("Ürün Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var itemToDelete = await _productService.TGetByIDAsync(id);
            if (itemToDelete == null)
                return NotFound("Ürün bulunamadı");
            await _productService.TDeleteAsync(itemToDelete);
            return Ok("Ürün Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.TGetByIDAsync(id);
            if (product == null)
                return NotFound();
            var dto = _mapper.Map<ResultProductDto>(product);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            var product = await _productService.TGetByIDAsync(id);
            if (product == null)
                return NotFound("Ürün bulunamadı");
            _mapper.Map(updateProductDto, product);
            await _productService.TUpdateAsync(product);
            return Ok("Ürün Güncellendi");
        }
    }
}