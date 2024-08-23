using CarBook.Dto.CarReviewDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailComponents;

public class _CarDetailReviewTabComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _CarDetailReviewTabComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync("http://localhost:5214/api/CarReviews/GetCarReviewsByCarId/" + id);
		if (responseMessage.IsSuccessStatusCode)
		{
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<GetAllCarReviewDto>>(jsonData);
			return View(values);
		}
		return View();
	}
}
