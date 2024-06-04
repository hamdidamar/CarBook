using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class RentACarsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.MainPage = "Ana Sayfa";
            ViewBag.MainLink = "/default";
            ViewBag.SubPage = "Araç Kirala";
            ViewBag.PageTitle = "Araç Kirala";

            var LocationId = TempData["LocationId"];
            var book_pick_date = TempData["book_pick_date"];
            var book_off_date = TempData["book_off_date"];
            var time_pick = TempData["time_pick"];
            var time_off = TempData["time_off"];
            ViewBag.LocationId = LocationId;
            ViewBag.book_pick_date = book_pick_date;
            ViewBag.book_off_date = book_off_date;
            ViewBag.time_pick = time_pick;  
            ViewBag.time_off = time_off;
         
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5214/api/RentACars?LocationId={LocationId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAllRentACarDto>>(jsonData);
                return View(values);
            }

            return View();

        }
    }
}
