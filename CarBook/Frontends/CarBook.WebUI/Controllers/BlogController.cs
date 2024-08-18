using CarBook.Dto.BlogCommentDtos;
using CarBook.Dto.BlogDtos;
using CarBook.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
        ViewBag.BlogId = id;

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5214/api/Blogs/GetAllWithIncludes");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllBlogWithIncludesDto>>(jsonData);
            return View(values.Where(x => x.Id == id).FirstOrDefault());
        }
        return View();
    }


    [HttpGet]
    public PartialViewResult AddComment()
    {
        return PartialView();
    }

    [HttpPost]
    public async Task<IActionResult> AddComment(CreateBlogCommentDto createBlogCommentDto)
    {

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createBlogCommentDto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("http://localhost:5214/api/BlogComments", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Default");
        }
        return View();
    }

}
