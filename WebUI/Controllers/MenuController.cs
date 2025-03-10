using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Constants;
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
    }
}
