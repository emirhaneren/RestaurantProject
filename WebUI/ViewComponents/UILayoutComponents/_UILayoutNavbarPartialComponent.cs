using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutNavbarPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
