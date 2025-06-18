using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Constants;
using WebUI.Dtos.MessageDtos;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactUsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg =await client.GetAsync(WebServiceAdresses.messageApi);
            if(responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> GetMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync(ApiHelper.ConfigureApiUrl(WebServiceAdresses.messageIdApi, id));
            if(responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetMessageDto>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
