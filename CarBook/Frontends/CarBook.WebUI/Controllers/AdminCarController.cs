using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using CarBook.Dto.ColorDtos;
using CarBook.Dto.ModelDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5214/api/Cars/GetAllWithIncludes");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAllCarWithIncludesDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var client = _httpClientFactory.CreateClient();
            //var brandsMessage = await client.GetAsync("http://localhost:5214/api/Brands");
            var modelMessage = await client.GetAsync("http://localhost:5214/api/Models");
            var colorMessage = await client.GetAsync("http://localhost:5214/api/Colors");
            //var jsonDataBrands = await brandsMessage.Content.ReadAsStringAsync();
            var jsonDataModels = await modelMessage.Content.ReadAsStringAsync();
            var jsonDataColors = await colorMessage.Content.ReadAsStringAsync();
            //var valuesBrands = JsonConvert.DeserializeObject<List<GetAllModelDto>>(jsonDataBrands);
            var valuesModels = JsonConvert.DeserializeObject<List<GetAllModelDto>>(jsonDataModels);
            var valuesColors = JsonConvert.DeserializeObject<List<GetAllColorDto>>(jsonDataColors);

            //List<SelectListItem> brandValues = (from b in valuesBrands
            //                                    select new SelectListItem
            //                                    {
            //                                        Text = b.Name,
            //                                        Value = b.Id
            //                                    }).ToList();

            List<SelectListItem> modelValues = (from m in valuesModels
                                                select new SelectListItem
                                                {
                                                    Text = m.Name,
                                                    Value = m.Id
                                                }).ToList();

            List<SelectListItem> colorValues = (from b in valuesColors
                                                select new SelectListItem
                                                {
                                                    Text = b.Name,
                                                    Value = b.Id
                                                }).ToList();

            //ViewBag.BrandValues = brandValues;
            ViewBag.ModelValues = modelValues;
            ViewBag.ColorValues = colorValues;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarDto createCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5214/api/Cars/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Remove(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5214/api/Cars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
