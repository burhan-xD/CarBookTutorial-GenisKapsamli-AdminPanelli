using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Views.UILayout
{
    public class _ScriptCoverUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
