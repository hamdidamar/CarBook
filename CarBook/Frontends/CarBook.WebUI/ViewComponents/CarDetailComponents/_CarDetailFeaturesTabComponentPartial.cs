using CarBook.Dto.CarDtos;
using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailComponents;

public class _CarDetailFeaturesTabComponentPartial:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _CarDetailFeaturesTabComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessageFeatures = await client.GetAsync("http://localhost:5214/api/Features");
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
                    if (!values.Where(x => x.FeatureId == featureToAdd.FeatureId).ToList().Any())
                    {
                        values.Add(featureToAdd);
                    }
                }
            }
            return View(values);
        }
        return View();
    }
}
