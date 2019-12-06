using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanceCon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DanceCon.Controllers
{
    public class AcountController : Controller
    {
        protected UserManager<IdentityUser> UserManager { get; }

        protected SignInManager<IdentityUser> SignInManager { get; }

        public AcountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();


        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser(viewModel.Login) { Email = viewModel.Email };
                var result = await UserManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                     await UserManager.AddToRoleAsync(user, "User");

                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();


        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(viewModel.Login,
                                        viewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                
                    ModelState.AddModelError(string.Empty, "Nie można się zalogować!");
               
            }
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}