using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class PricingController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.MainPage = "Ana Sayfa";
            ViewBag.MainLink = "/default";
            ViewBag.SubPage = "Fiyatlar";
            ViewBag.PageTitle = "Fiyatlar";
            return View();
        }
    }
}
