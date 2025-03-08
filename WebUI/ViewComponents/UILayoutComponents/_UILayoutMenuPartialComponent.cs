using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutMenuPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
