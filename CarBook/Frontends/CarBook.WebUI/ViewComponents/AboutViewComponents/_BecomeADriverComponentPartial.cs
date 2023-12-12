﻿using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents;

public class _BecomeADriverComponentPartial:ViewComponent
{

    private readonly IHttpClientFactory _httpClientFactory;

    public _BecomeADriverComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
