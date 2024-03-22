using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.BlogWiewComponents
{
    public class _BlogDetailParagraphComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
