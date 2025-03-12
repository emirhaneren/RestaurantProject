using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Constants;
using WebUI.Dtos.BasketDtos;
using WebUI.Dtos.ProductDtos;

namespace WebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync(WebServiceAdresses.productGetWithCategoryApi);
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket(int id)
        {
            CreateBasketDto createBasketDto = new CreateBasketDto();
            createBasketDto.ProductID = id;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, GeneralConstants.appJson);
            var responseMsg = await client.PostAsync(WebServiceAdresses.basketPostApi, stringContent);
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(createBasketDto);
        }
    }
}
