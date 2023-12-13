using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents;

public class _LastCarsWithIncludesComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _LastCarsWithIncludesComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5214/api/Cars/GetLastCarsWithIncludes");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllCarWithIncludesDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
