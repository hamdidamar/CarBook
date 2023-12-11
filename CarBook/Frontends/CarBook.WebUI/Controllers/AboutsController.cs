using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class AboutsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
