using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers;

public class CarController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CarController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.MainPage = "Ana Sayfa";
        ViewBag.MainLink = "/default";
        ViewBag.SubPage = "Arabalar";
        ViewBag.PageTitle = "Arabalar";

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5214/api/Cars/GetAllWithIncludes");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllCarWithIncludesDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    public async Task<IActionResult> Detail(string id)
    {
        ViewBag.MainPage = "Ana Sayfa";
        ViewBag.MainLink = "/default";
        ViewBag.SubPage = "Araç Detay";
        ViewBag.PageTitle = "Araç Özellikleri";
        ViewBag.carId =  id;

        return View();
    }
}
