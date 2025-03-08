using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutAboutPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
