using CarBook.Dto.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents;

public class _BlogDetailMainAuthorComponentPartial:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _BlogDetailMainAuthorComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5214/api/Authors/id?id="+id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetAuthorDto>(jsonData);
            return View(values);
        }
        return View();
    }
}
