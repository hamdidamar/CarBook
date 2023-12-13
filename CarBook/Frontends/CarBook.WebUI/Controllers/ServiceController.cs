using CarBook.Dto.ServiceDtos;
using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers;

public class ServiceController : Controller
{
    
    public IActionResult Index()
    {
        ViewBag.MainPage = "Ana Sayfa";
        ViewBag.MainLink = "/default";
        ViewBag.SubPage = "Hizmetlerimiz";
        ViewBag.PageTitle = "Hizmetlerimiz";
        return View();
    }
}
