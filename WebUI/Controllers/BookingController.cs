using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Constants;
using WebUI.Dtos.BookingDtos;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync(WebServiceAdresses.bookingApi);
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Description = "Rezervasyon Alındı";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, GeneralConstants.appJson);
            var responseMsg = await client.PostAsync(WebServiceAdresses.bookingApi, stringContent);
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.DeleteAsync(ApiHelper.ConfigureApiUrl(WebServiceAdresses.bookingIdApi, id));
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync(ApiHelper.ConfigureApiUrl(WebServiceAdresses.bookingGetByIdApi, id));
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, GeneralConstants.appJson);
            var responseMsg = await client.PutAsync(WebServiceAdresses.bookingApi, stringContent);
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> UpdateBookingStatusApproved(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync(ApiHelper.ConfigureApiUrl(WebServiceAdresses.bookingApproveApi, id));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateBookingStatusCanceled(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync(ApiHelper.ConfigureApiUrl(WebServiceAdresses.bookingCancelApi,id));
            return RedirectToAction("Index");
        }
    }
}
