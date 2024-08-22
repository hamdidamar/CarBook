using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardLineChartComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _AdminDashboardLineChartComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5214/api/Blogs/GetAllWithIncludes");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAllBlogWithIncludesDto>>(jsonData);
                return View(values.OrderByDescending(x=>x.CreatedDate).Take(5).ToList());
            }
            return View();
        }
	}
}
