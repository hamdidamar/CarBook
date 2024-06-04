using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class RentACarsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.LocationId = TempData["LocationId"];
            return View();
        }
    }
}
