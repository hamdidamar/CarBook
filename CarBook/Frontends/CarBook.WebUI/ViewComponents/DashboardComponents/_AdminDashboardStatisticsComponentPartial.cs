using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents;

public class _AdminDashboardStatisticsComponentPartial:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        Random random = new Random();
        var client = _httpClientFactory.CreateClient();

        #region carCount
        var responseMessage = await client.GetAsync("http://localhost:5214/api/Statistics/GetCarCount");
        if (responseMessage.IsSuccessStatusCode)
        {
            int carCountRandom = random.Next(0, 101);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData);
            ViewBag.carCount = values.count;
            ViewBag.carCountRandom = carCountRandom;
        }
        #endregion

        #region locationCount
        var responseMessage2 = await client.GetAsync("http://localhost:5214/api/Statistics/GetLocationCount");
        if (responseMessage2.IsSuccessStatusCode)
        {
            int locationCountRandom = random.Next(0, 101);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData2);
            ViewBag.locationCount = values2.count;
            ViewBag.locationCountRandom = locationCountRandom;
        }
        #endregion

        #region brandCount
        var responseMessage5 = await client.GetAsync("http://localhost:5214/api/Statistics/GetBrandCount");
        if (responseMessage5.IsSuccessStatusCode)
        {
            int brandCountRandom = random.Next(0, 101);
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            var values5 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData5);
            ViewBag.brandCount = values5.count;
            ViewBag.brandCountRandom = brandCountRandom;
        }
        #endregion

        #region avgRentPriceForDaily
        var responseMessage6 = await client.GetAsync("http://localhost:5214/api/Statistics/GetAvgRentPriceForDaily");
        if (responseMessage6.IsSuccessStatusCode)
        {
            int avgRentPriceForDailyRandom = random.Next(0, 101);
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            var values6 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData6);
            ViewBag.avgRentPriceForDaily = values6.price.ToString("0.00"); ;
            ViewBag.avgRentPriceForDailyRandom = avgRentPriceForDailyRandom;
        }
        #endregion

        return View();
    }

}
