using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers;

public class BlogController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BlogController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.MainPage = "Ana Sayfa";
        ViewBag.MainLink = "/default";
        ViewBag.SubPage = "Blog";
        ViewBag.PageTitle = "Blog";

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5214/api/Blogs/GetAllWithIncludes");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllBlogWithIncludesDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    public async Task<IActionResult> Detail(string id)
    {
        ViewBag.MainPage = "Ana Sayfa";
        ViewBag.MainLink = "/default";
        ViewBag.SubPage = "Blog";
        ViewBag.PageTitle = "Blog";

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5214/api/Blogs/GetAllWithIncludes");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllBlogWithIncludesDto>>(jsonData);
            return View(values.Where(x=>x.id == id).FirstOrDefault());
        }
        return View();
    }
}
