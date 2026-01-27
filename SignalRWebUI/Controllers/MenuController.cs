using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

public class MenuController : Controller
{
    private readonly IProductApiService _productApiService;
    private readonly IBasketApiService _basketApiService;
    private readonly IMapper _mapper;

    public MenuController(IProductApiService productApiService, IMapper mapper, IBasketApiService basketApiService)
    {
        _productApiService = productApiService;
        _mapper = mapper;
        _basketApiService = basketApiService;
    }

    public async Task<IActionResult> Index() => View(await _productApiService.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> AddBasket(int id)
    {
        // Ortak tablo / Product tablosundan bilgileri çek
        var product = await _productApiService.GetByIdAsync(id); // ProductName, Price vs.

        if (product == null)
            return BadRequest("Ürün bulunamadı");

        // Sepete ekleme
        var basketViewModel = new CreateBasketViewModel
        {
            ProductID = id,
            MenuTableID = 1,
            Status = "Aktif", 
            Products = new List<BasketProductViewModel>()
        };

        // Ürünü Products listesine ekle
        basketViewModel.Products.Add(new BasketProductViewModel
        {
            ProductID = product.ProductID,
            ProductName = product.ProductName,
            Quantity = 1,
            Price = product.Price,
            TotalPrice = product.Price * 1,            
        });

        // ViewModel → DTO
        var createBasketDto = _mapper.Map<CreateBasketDto>(basketViewModel);

        await _basketApiService.CreateAsync(createBasketDto);

        return Ok();
    }




}


    //[HttpPost]
    //public async Task<IActionResult> AddBasket(int id , CreateBasketViewModel createBasketViewModel)
    //{
    //    createBasketViewModel.ProductID = id;
    //    createBasketViewModel.MenuTableID = 2;
    //    createBasketViewModel.Status = "Aktif";
    //    var createBasketDto = _mapper.Map<CreateBasketDto>(createBasketViewModel);
    //    await _basketApiService.CreateAsync(createBasketDto);
    //    return RedirectToAction("Index");
    //}

