using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Dtos.IdentityDtos;

namespace WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Index(RegisterDto registerDto)
        {
            var AppUser = new AppUser()
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                UserName = registerDto.UserName,
                Email = registerDto.Mail
            };
            var result = await _userManager.CreateAsync(AppUser, registerDto.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
