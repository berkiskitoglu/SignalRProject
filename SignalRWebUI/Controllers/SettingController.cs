using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.ViewModels.IdentityViewModels;

namespace SignalRWebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            AppUser values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel
            {
                Name = values.Name,
                Surname = values.Surname,
                Username = values.UserName,
                Mail = values.Email
            };
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            if (!ModelState.IsValid)
                return View(userEditViewModel);

            if (userEditViewModel.Password != userEditViewModel.ConfirmPassword)
            {
                ModelState.AddModelError("", "Şifreler eşleşmiyor");
                return View(userEditViewModel);
            }

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = userEditViewModel.Name;
            user.Surname = userEditViewModel.Surname;
            user.UserName = userEditViewModel.Username;
            user.Email = userEditViewModel.Mail;

            IdentityResult result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(userEditViewModel.Password))
                {
                    await _userManager.RemovePasswordAsync(user);
                    await _userManager.AddPasswordAsync(user, userEditViewModel.Password);
                }
                return RedirectToAction("CategoryList", "Category");
            }

            foreach (IdentityError item in result.Errors)
                ModelState.AddModelError("", item.Description);

            return View(userEditViewModel);
        }
    }
}