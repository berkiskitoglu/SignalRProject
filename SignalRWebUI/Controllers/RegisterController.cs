using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.ViewModels.IdentityViewModels;

namespace SignalRWebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return View(registerViewModel);

            AppUser appUser = new AppUser
            {
                Name = registerViewModel.Name,
                Surname = registerViewModel.Surname,
                UserName = registerViewModel.Username,
                Email = registerViewModel.Mail
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, registerViewModel.Password);

            if (result.Succeeded)
                return RedirectToAction("Index", "Login");

            foreach (IdentityError item in result.Errors)
                ModelState.AddModelError("", item.Description);

            return View(registerViewModel);
        }
    }
}