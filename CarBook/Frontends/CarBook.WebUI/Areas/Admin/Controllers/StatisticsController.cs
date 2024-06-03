using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Statistics")]
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
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

            #region authorCount
            var responseMessage3 = await client.GetAsync("http://localhost:5214/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int authorCountRandom = random.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData3);
                ViewBag.authorCount = values3.count;
                ViewBag.authorCountRandom = authorCountRandom;
            }
            #endregion

            #region blogCount
            var responseMessage4 = await client.GetAsync("http://localhost:5214/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int blogCountRandom = random.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData4);
                ViewBag.blogCount = values4.count;
                ViewBag.blogCountRandom = blogCountRandom;
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

            #region avgRentPriceForWeekly
            var responseMessage7 = await client.GetAsync("http://localhost:5214/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int avgRentPriceForWeeklyRandom = random.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData7);
                ViewBag.avgRentPriceForWeekly = values7.price.ToString("0.00");
                ViewBag.avgRentPriceForWeeklyRandom = avgRentPriceForWeeklyRandom;
            }
            #endregion

            #region avgRentPriceForMonthly
            var responseMessage8 = await client.GetAsync("http://localhost:5214/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int avgRentPriceForMonthlyRandom = random.Next(0, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData8);
                ViewBag.avgRentPriceForMonthly = values8.price.ToString("0.00");
                ViewBag.avgRentPriceForMonthlyRandom = avgRentPriceForMonthlyRandom;
            }
            #endregion

            #region carCountByTranmissionIsAuto
            var responseMessage9 = await client.GetAsync("http://localhost:5214/api/Statistics/GetCarCountByTranmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int carCountByTranmissionIsAutoRandom = random.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData9);
                ViewBag.carCountByTranmissionIsAuto = values9.count;
                ViewBag.carCountByTranmissionIsAutoRandom = carCountByTranmissionIsAutoRandom;
            }
            #endregion

            #region brandNameByMaxCar
            var responseMessage10 = await client.GetAsync("http://localhost:5214/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage10.IsSuccessStatusCode)
            {
                int brandNameByMaxCarRandom = random.Next(0, 101);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values10 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData10);
                ViewBag.brandNameByMaxCar = values10.name;
                ViewBag.brandNameByMaxCarRandom = brandNameByMaxCarRandom;
            }
            #endregion

            #region blogTitleByMaxBlogComment
            var responseMessage11 = await client.GetAsync("http://localhost:5214/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseMessage11.IsSuccessStatusCode)
            {
                int blogTitleByMaxBlogCommentRandom = random.Next(0, 101);
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var values11 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData11);
                ViewBag.blogTitleByMaxBlogComment = values11.title;
                ViewBag.blogTitleByMaxBlogCommentRandom = blogTitleByMaxBlogCommentRandom;
            }
            #endregion

            #region carCountByKmSmallerThen1000
            var responseMessage12 = await client.GetAsync("http://localhost:5214/api/Statistics/GetCarCountByKmSmallerThenTousand");
            if (responseMessage12.IsSuccessStatusCode)
            {
                int carCountByKmSmallerThen1000Random = random.Next(0, 101);
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData12);
                ViewBag.carCountByKmSmallerThen1000 = values12.price;
                ViewBag.carCountByKmSmallerThen1000Random = carCountByKmSmallerThen1000Random;
            }
            #endregion

            #region carCountByFuelGasolineOrDiesel
            var responseMessage13 = await client.GetAsync("http://localhost:5214/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessage13.IsSuccessStatusCode)
            {
                int carCountByFuelGasolineOrDieselRandom = random.Next(0, 101);
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData13);
                ViewBag.carCountByFuelGasolineOrDiesel = values13.count;
                ViewBag.carCountByFuelGasolineOrDieselRandom = carCountByFuelGasolineOrDieselRandom;
            }
            #endregion

            #region carCountByFuelElectric
            var responseMessage14 = await client.GetAsync("http://localhost:5214/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage14.IsSuccessStatusCode)
            {
                int carCountByFuelElectricRandom = random.Next(0, 101);
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData14);
                ViewBag.carCountByFuelElectric = values14.count;
                ViewBag.carCountByFuelElectricRandom = carCountByFuelElectricRandom;
            }
            #endregion

            #region carBrandAndModelByRentPriceDailyMax
            var responseMessage15 = await client.GetAsync("http://localhost:5214/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage15.IsSuccessStatusCode)
            {
                int carBrandAndModelByRentPriceDailyMaxRandom = random.Next(0, 101);
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData15);
                ViewBag.carBrandAndModelByRentPriceDailyMax = values15.brandAndModel;
                ViewBag.carBrandAndModelByRentPriceDailyMaxRandom = carBrandAndModelByRentPriceDailyMaxRandom;
            }
            #endregion

            #region carBrandAndModelByRentPriceDailyMin
            var responseMessage16 = await client.GetAsync("http://localhost:5214/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage16.IsSuccessStatusCode)
            {
                int carBrandAndModelByRentPriceDailyMinRandom = random.Next(0, 101);
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<GetAllStatisticsDto>(jsonData16);
                ViewBag.carBrandAndModelByRentPriceDailyMin = values16.brandAndModel;
                ViewBag.carBrandAndModelByRentPriceDailyMinRandom = carBrandAndModelByRentPriceDailyMinRandom;
            }
            #endregion

            return View();
        }
    }
}
