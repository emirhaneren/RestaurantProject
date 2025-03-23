using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Constants;
using WebUI.Dtos.AboutDtos;
using WebUI.Dtos.ValidationDtos;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync(WebServiceAdresses.aboutApi);
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync(ApiHelper.ConfigureApiUrl(WebServiceAdresses.aboutGetByIdApi, id));
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            updateAboutDto.ImageUrl = "/uiAssets/images/about-img.png";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAboutDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, GeneralConstants.appJson);
            var responseMsg = await client.PutAsync(WebServiceAdresses.aboutApi, stringContent);
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.Clear();
                var errorResponse = await responseMsg.Content.ReadFromJsonAsync<ApiValidationErrorResponseDto>();
                if (errorResponse?.Errors != null)
                {
                    foreach (var error in errorResponse.Errors)
                    {
                        foreach (var errorMessage in error.Value)
                        {
                            ModelState.AddModelError(error.Key, errorMessage);
                        }
                    }
                }
                return View(updateAboutDto);
            }
        }
    }
}
