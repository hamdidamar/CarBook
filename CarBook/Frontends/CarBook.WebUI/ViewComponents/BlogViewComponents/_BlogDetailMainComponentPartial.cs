﻿using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents;

public class _BlogDetailMainComponentPartial:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _BlogDetailMainComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5214/api/Blogs/GetAllWithIncludes");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllBlogWithIncludesDto>>(jsonData);
            return View(values.Where(x=>x.id == id).ToList());
        }
        return View();
    }
}
