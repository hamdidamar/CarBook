using CarBook.Dto.AboutDtos;
using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/CarFeature")]
    public class CarFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageFeatures = await client.GetAsync("http://localhost:5214/api/Features" );
            var responseMessage = await client.GetAsync("http://localhost:5214/api/CarFeatures/GetCarFeaturesWithIncludesByCarId/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAllCarFeatureWithIncludesDto>>(jsonData);
                if (responseMessageFeatures.IsSuccessStatusCode)
                {
                    var jsonDataFeatures = await responseMessageFeatures.Content.ReadAsStringAsync();
                    var valuesFeatures = JsonConvert.DeserializeObject<List<GetAllFeatureDto>>(jsonDataFeatures);
                    foreach (var feature in valuesFeatures)
                    {
                        var featureToAdd = new GetAllCarFeatureWithIncludesDto { Available = false, CarId = id, FeatureId = feature.Id, FeatureName = feature.Name };
                        if (!values.Where(x=>x.FeatureId == featureToAdd.FeatureId).ToList().Any())
                        {
                            values.Add(featureToAdd);
                        }
                    }
                }
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<GetAllCarFeatureWithIncludesDto> getAllCarFeatureWithIncludesDtos)
        {
            var isAllRequestSuccess = true;
            foreach (var item in getAllCarFeatureWithIncludesDtos.Where(x=>x.id != null ).ToList())
            {
                var updateCarFeatureDto = new UpdateCarFeatureDto
                { Available = item.Available, CarId = item.CarId, FeatureId = item.FeatureId, id = item.id };
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateCarFeatureDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync($"http://localhost:5214/api/CarFeatures/", content);
                if (!responseMessage.IsSuccessStatusCode)
                {
                    isAllRequestSuccess = false;
                   
                }
            }

            foreach (var item in getAllCarFeatureWithIncludesDtos.Where(x => x.id == null && x.Available).ToList())
            {
                var createCarFeatureDto = new CreateCarFeatureDto
                { Available = item.Available, CarId = item.CarId, FeatureId = item.FeatureId };
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createCarFeatureDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync($"http://localhost:5214/api/CarFeatures/", content);
                if (!responseMessage.IsSuccessStatusCode)
                {
                    isAllRequestSuccess = false;

                }
            }

            if (isAllRequestSuccess)
            {
                return RedirectToAction("Index", "AdminCar");
            }
            return RedirectToAction("Index");
        }



    }
}
