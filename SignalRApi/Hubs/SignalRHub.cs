using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public async Task SendStatistics()
        {
            var categoryCount = await _categoryService.TReceiveCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

            var productCount = await _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", productCount);

            var activeCategoryCount = await _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);

            var passiveCategoryCount = await _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);

            var productCountByCategoryNameHamburger = await _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", productCountByCategoryNameHamburger);

            var productCountByCategoryNameDrink = await _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", productCountByCategoryNameDrink);

            var avgProductPrice = await _productService.TProductPriceAverage();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", avgProductPrice.ToString("0.00") + "₺");

            var productNameByMinPrice = await _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", productNameByMinPrice);

            var avgHamburgerPrice = await _productService.TAverageProductPriceHamburger();
            await Clients.All.SendAsync("ReceiveAvgHamburgerPrice", avgHamburgerPrice.ToString("0.00") + "₺");

            var orderCount = await _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveOrderCount",orderCount);

            var activeOrderCount = await _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

            var lastOrderPrice = await _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice.ToString("0.00") + "₺");

            var totalMoneyCase = await _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCase", totalMoneyCase.ToString("0.00") + "₺");

            var totalTableCount = await _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveTotalTableCount", totalTableCount);

            var productNameByMaxPrice = await _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", productNameByMaxPrice);

        }

        public async Task SendProgress()
        {
            var totalBalance = await _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalBalance", totalBalance.ToString("0.00" + "₺"));

            var activeOrderCount = await _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

            var activeTableCount = await _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveTableCount", activeTableCount);
        }

        public async Task GetBookingList() 
        { 
            var bookingList = await _bookingService.TGetListAllAsync();
            await Clients.All.SendAsync("ReceiveBookingList", bookingList);
        }

        public async Task SendNotification()
        {
            var unreadNotifications = await _notificationService.TGetUnreadNotificationCountAsync();
            await Clients.All.SendAsync("ReceiveUnreadNotification", unreadNotifications);

            var unreadNotificationList = await _notificationService.TGetlAllUnreadNotificationAsync();
            await Clients.All.SendAsync("ReceiveUnreadNotificationList", unreadNotificationList);
        }
    }
}
