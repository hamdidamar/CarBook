﻿using CarBook.Dto.BlogCommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/BlogComment")]
    public class BlogCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5214/api/BlogComments");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAllBlogCommentWithIncludesDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [Route("Remove/{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5214/api/BlogComments/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("BlogCommentsById/{id}")]
        public async Task<IActionResult> BlogCommentsById(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5214/api/BlogComments"); // yada getbyid de include eklenip çekilebilir çok veri olunca
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAllBlogCommentWithIncludesDto>>(jsonData);
                return View(values.Where(x=>x.BlogId == id).ToList());
            }
            return View();
        }

    }
}
