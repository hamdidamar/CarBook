using CarBook.Dto.BlogTagDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents;

public class _BlogDetailMainTagsComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _BlogDetailMainTagsComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5214/api/BlogTags/GetAllByBlogId/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllBlogTagDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
