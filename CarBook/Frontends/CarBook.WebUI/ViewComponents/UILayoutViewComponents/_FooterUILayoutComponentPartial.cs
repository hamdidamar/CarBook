using CarBook.Dto.FooterDtos;
using CarBook.Dto.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.ViewComponents.UILayoutViewComponents;

public class _FooterUILayoutComponentPartial:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _FooterUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5214/api/Footers");
        var responseMessageSocial = await client.GetAsync("http://localhost:5214/api/SocialMedias");
        if (responseMessageSocial.IsSuccessStatusCode)
        {
            var jsonDataSocial = await responseMessageSocial.Content.ReadAsStringAsync();
            var valuesSocial = JsonConvert.DeserializeObject<List<GetAllSocialMediaDto>>(jsonDataSocial);
            ViewBag.socialMedia = valuesSocial;
        }

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllFooterDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
