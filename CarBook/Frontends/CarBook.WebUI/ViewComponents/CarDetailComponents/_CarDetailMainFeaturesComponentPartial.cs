using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.CarDetailComponents;

public class _CarDetailMainFeaturesComponentPartial:ViewComponent
{
	private readonly IHttpClientFactory _httpClientFactory;

	public _CarDetailMainFeaturesComponentPartial(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<IViewComponentResult> InvokeAsync(string id)
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync("http://localhost:5214/api/Cars/GetAllWithIncludes");
		if (responseMessage.IsSuccessStatusCode)
		{
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<GetAllCarWithIncludesDto>>(jsonData);
			return View(values.Where(x=>x.Id== id).FirstOrDefault());
		}
		return View();
	}
}
