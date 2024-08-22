﻿using CarBook.Dto.AboutDtos;
using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardCarPricingComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _AdminDashboardCarPricingComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5214/api/CarPricings/GetAllWithIncludes");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<GetAllCarPricingWithIncludesDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
