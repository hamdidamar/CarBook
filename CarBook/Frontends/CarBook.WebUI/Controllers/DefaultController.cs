using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5214/api/Locations");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllLocationDto>>(jsonData);
            var locations = (from x in values
                             select new SelectListItem
                             {
                                 Text = x.Name,
                                 Value = x.Id
                             }).ToList();

            ViewBag.Locations = locations;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string LocationId,string book_pick_date,string book_off_date,string time_pick,string time_off)
        {
            TempData["LocationId"] = LocationId;
            TempData["book_pick_date"] = book_pick_date;
            TempData["book_off_date"] = book_off_date;
            TempData["time_pick"] = time_pick;
            TempData["time_off"] = time_off;
            return RedirectToAction("Index","RentACars");
        }
    }
}
