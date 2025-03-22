using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.RapidApiDtos;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class FoodRapidApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=100"),
                Headers =
    {
        { "x-rapidapi-key", "a61175a7ffmsh7df93b2daf201a9p19d751jsn011b12cc2445" },
        { "x-rapidapi-host", "tasty.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<List<ResultTastyApi>>(body);
                //return View(values.ToList());
                var root = JsonConvert.DeserializeObject<RootTastyApi>(body);
                var values =root.Results;
                return View(values.ToList());
            }
        }
    }
}
