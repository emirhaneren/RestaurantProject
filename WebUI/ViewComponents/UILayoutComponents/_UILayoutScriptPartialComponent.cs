using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutScriptPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
