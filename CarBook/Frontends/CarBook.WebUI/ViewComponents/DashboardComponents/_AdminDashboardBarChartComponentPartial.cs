using CarBook.Dto.BlogDtos;
using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardBarChartComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _AdminDashboardBarChartComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5214/api/Cars/GetAllWithIncludes");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAllCarWithIncludesDto>>(jsonData);
                ViewBag.carCount = values.Count();
                ViewBag.locationCount = values.Select(x => x.BrandName).ToList().Distinct().Count();
                ViewBag.brands = values.Select(x => x.BrandName).Distinct().ToList();
                ViewBag.carCountByLocations = values
                                            .GroupBy(x => x.BrandName)
                                            .Select(group => new { BrandName = group.Key, Count = group.Count() })
                                            .ToList().Select(x => x.Count).ToList();
                return View(values);
            }
            return View();
        }
	}
}
