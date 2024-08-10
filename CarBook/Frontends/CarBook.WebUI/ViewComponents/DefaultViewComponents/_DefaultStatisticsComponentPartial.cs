using CarBook.Dto.CarDtos;
using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents;

public class _DefaultStatisticsComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        #region carCount
        Random random = new Random();
        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.GetAsync("http://localhost:5214/api/Statistics/GetCarCount");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData);
            ViewBag.carCount = values.count;
        }
        #endregion

        #region locationCount
        var responseMessage2 = await client.GetAsync("http://localhost:5214/api/Statistics/GetLocationCount");
        if (responseMessage2.IsSuccessStatusCode)
        {
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData2);
            ViewBag.locationCount = values2.count;
        }
        #endregion

        #region brandCount
        var responseMessage5 = await client.GetAsync("http://localhost:5214/api/Statistics/GetBrandCount");
        if (responseMessage5.IsSuccessStatusCode)
        {
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            var values5 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData5);
            ViewBag.brandCount = values5.count;
        }
        #endregion


        #region carCountByFuelElectric
        var responseMessage14 = await client.GetAsync("http://localhost:5214/api/Statistics/GetCarCountByFuelElectric");
        if (responseMessage14.IsSuccessStatusCode)
        {
            var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
            var values14 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData14);
            ViewBag.carCountByFuelElectric = values14.count;
        }
        #endregion

        #region avgRentPriceForDaily
        var responseMessage6 = await client.GetAsync("http://localhost:5214/api/Statistics/GetAvgRentPriceForDaily");
        if (responseMessage6.IsSuccessStatusCode)
        {
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            var values6 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData6);
            ViewBag.avgRentPriceForDaily = values6.price.ToString("0.00"); ;
        }
        #endregion

        return View();
    }
}
