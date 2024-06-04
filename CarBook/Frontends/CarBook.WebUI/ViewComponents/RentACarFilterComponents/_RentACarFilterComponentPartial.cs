using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarFilterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke(string LocationId)
        {
            TempData["LocationId"]=LocationId;
            return View();
        }
    }
}
