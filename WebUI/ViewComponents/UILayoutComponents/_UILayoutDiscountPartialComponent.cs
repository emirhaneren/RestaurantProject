using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutDiscountPartialComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
