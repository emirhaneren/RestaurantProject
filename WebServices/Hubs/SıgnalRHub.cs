using BusinessLayer.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace WebServices.Hubs
{
    public class SıgnalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public SıgnalRHub(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
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
            var value =_productService.TProductPriceByHamburger();
            await Clients.All.SendAsync("ReceiveHamburgerCount", value);
        }
        public async Task SoftDrinkCount()
        {
            var value =_productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReveiceSoftDrinkCount");
        }
    }
}
