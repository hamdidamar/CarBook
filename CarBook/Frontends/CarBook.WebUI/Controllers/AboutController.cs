using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers;

public class AboutController : Controller
{
    public IActionResult Index()
    {
        ViewBag.MainPage = "Ana Sayfa";
        ViewBag.MainLink = "/default";
        ViewBag.SubPage = "Hakkımızda";
        ViewBag.PageTitle = "Hakkımızda";
        return View();
    }
}
