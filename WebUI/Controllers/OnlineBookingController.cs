using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Constants;
using WebUI.Dtos.BookingDtos;
using WebUI.Dtos.ValidationDtos;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class OnlineBookingController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public OnlineBookingController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, GeneralConstants.appJson);
            var responseMsg=await client.PostAsync(WebServiceAdresses.bookingApi, content);
            if(responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            else
            {
                ModelState.Clear();
                var errorResponse = await responseMsg.Content.ReadFromJsonAsync<ApiValidationErrorResponseDto>();
                if (errorResponse?.Errors != null)
                {
                    foreach (var error in errorResponse.Errors)
                    {
                        foreach(var errorMessage in error.Value)
                        {
                            ModelState.AddModelError(error.Key, errorMessage);
                        }
                    }
                }
                return View(createBookingDto);
            }
        }
    }
}
