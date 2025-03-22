using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Constants;
using WebUI.Dtos.CategoryDtos;

namespace WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutMenuCategoryPartialComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutMenuCategoryPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync(WebServiceAdresses.categoryApi);
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
