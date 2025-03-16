using BusinessLayer.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace WebServices.Hubs
{
    public class SıgnalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public SıgnalRHub(IProductService productService, ICategoryService categoryService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public async Task SendCategoryCount()
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
        public async Task SendProductCount()
        {
            var value = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value);
        }
        public async Task ActiveCategoryCount()
        {
            var value = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value);
        }
        public async Task PassiveCategoryCount()
        {
            var value = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReveicePassiveCategoryCount", value);
        }
        public async Task HamburgerCount()
        {
            var value = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveHamburgerCount", value);
        }
        public async Task SoftDrinkCount()
        {
            var value = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReveiceSoftDrinkCount", value);
        }
        public async Task AverageProductPrice()
        {
            var value = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveAverageProductPrice", value.ToString("0.00") + "₺");
        }
        public async Task ProductByMaxPrice()
        {
            var value = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductByMaxPrice", value);
        }
        public async Task ProductByMinPrice()
        {
            var value = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveProductByMinPrice", value);
        }
        public async Task AverageHamburgerPrice()
        {
            var value = _productService.TProductPriceByHamburger();
            await Clients.All.SendAsync("ReceiveAverageHamburgerPrice", value.ToString("0.00") + "₺");
        }
        public async Task TotalOrderCount()
        {
            var value = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value);
        }
        public async Task TotalActiveOrderCount()
        {
            var value = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveTotalActiveOrderCount", value);
        }
        public async Task LastOrderPrice()
        {
            var value = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", value.ToString("0.00") + "₺");
        }
        public async Task TotalMoneyCaseAmount()
        {
            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.ToString("0.00") + "₺");
        }
        public async Task TotalTableCount()
        {
            var value = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveTotalTableCount", value);
        }
        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveAllBookingList", values);
        }
        public async Task GetNotificationCountByStatusFalse()
        {
            var values = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", values);

            var notifications = _notificationService.TGetAllNotificationByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationListByFalse", notifications);
        }
        public async Task GetMenuTableList()
        {
            var values = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveMenuTableStatus", values);
        }
    }
}
