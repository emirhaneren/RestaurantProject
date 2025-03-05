using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ProgressBarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
