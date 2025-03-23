using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Constants;
using WebUI.Dtos.BasketDtos;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            if (id == 0)
            {
                ViewBag.ErrorMessage = "Geçersiz masa numarası!";
                return View(new List<ResultBasketDto>());
            }
            ViewBag.MenuTableId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync(ApiHelper.ConfigureApiUrl(WebServiceAdresses.basketGetByProductNameApi, id));
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(values);
            }
            return View();
        }
         public async Task<IActionResult> DeleteBasket(int id,int tableId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.DeleteAsync(ApiHelper.ConfigureApiUrl(WebServiceAdresses.basketApi, id));

            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { id = tableId });
            }
            return NoContent();
        }
        public async Task<IActionResult> ChangeMenuTable(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync(ApiHelper.ConfigureApiUrl(WebServiceAdresses.menuTableIdFalseApi, id));
            return RedirectToAction("CustomerTableList", "CustomerTable");
        }
    }
}
