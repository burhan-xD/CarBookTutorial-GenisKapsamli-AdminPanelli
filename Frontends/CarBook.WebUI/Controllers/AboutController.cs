using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Hakkimizda";
            ViewBag.v2 = "Vizyon ve Misyon..._xD";
            return View();
        }
    }
}
