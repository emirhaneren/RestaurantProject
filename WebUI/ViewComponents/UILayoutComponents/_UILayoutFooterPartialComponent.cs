using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterPartialComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
