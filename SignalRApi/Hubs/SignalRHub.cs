using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;



        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
        }

        public async Task SendStatistic()
        {
            var value =  _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount",value);

            var value2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

            var value5 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", value5);

            var value6 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value6);

            var value7 = _productService.TAveragePriceOfProducts();
            await Clients.All.SendAsync("ReceiveAveragePriceOfProducts", value7.ToString("0.00" + "₺"));

            var value8 = _productService.TMaxPriceProductName();
            await Clients.All.SendAsync("ReceiveMaxPriceProductName", value8);

            var value9 = _productService.TMinPriceProductName();
            await Clients.All.SendAsync("ReceiveMinPriceProductName", value9);

            var value10 = _productService.TAverageProductPriceOfHamburger();
            await Clients.All.SendAsync("ReceiveAverageProductPriceOfHamburger", value10.ToString("0.00" + "₺"));

            var value11 = _orderService.TGetTotalOrderCount();
            await Clients.All.SendAsync("ReceiveGetTotalOrderCount", value11);

            var value12 = _orderService.TGetActiveOrderCount();
            await Clients.All.SendAsync("ReceiveGetActiveOrderCount", value12);

            var value13 = _orderService.TGetLastOrderPrice();
            await Clients.All.SendAsync("ReceiveGetLastOrderPrice", value13.ToString("0.00" + "₺"));

            var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value14.ToString("0.00" + "₺"));

            var value16 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value16);

        }

        }
    }

