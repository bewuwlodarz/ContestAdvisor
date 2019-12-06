using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanceCon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DanceCon.Controllers
{
    [Authorize(Roles="Admin")]
    public class RoleController : Controller
    {
        protected UserManager<IdentityUser> UserManager { get; }

        protected SignInManager<IdentityUser> SignInManager { get; }
        protected RoleManager<IdentityRole> RoleManager { get; }

        public RoleController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = RoleManager.Roles;
            return View(roles);
        }

      

     
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Add(RoleViewModel role, string roleName)
        {

            var ir = new IdentityRole(roleName);
            await RoleManager.CreateAsync(ir);
            role.RoleName = roleName;
            return RedirectToAction("Index", "Role");
        }
        [HttpGet]
        public async Task<IActionResult> Remove()
        {

            var roles = RoleManager.Roles;
            return View(roles);

        }
        [HttpPost]
        public async Task<IActionResult> Remove(string roleName)
        {

            var ir = new IdentityRole(roleName);
            await RoleManager.CreateAsync(ir);
            return RedirectToAction("Index", "Role");
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            if(role == null)
            {

                ViewBag.ErrorMessage = $"ROle with Id = {id} cannot be found";
                return View("NotFound");
            }
            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };
            foreach(var user in UserManager.Users)
            {
                if (await UserManager.IsInRoleAsync(user, role.Name))
                { model.Users.Add(user.UserName); }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await RoleManager.FindByIdAsync(model.Id);
            if (role == null)
            {

                ViewBag.ErrorMessage = $"ROle with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else {
                role.Name = model.RoleName;
               var result = await RoleManager.UpdateAsync(role);
                if(result.Succeeded)
                { return RedirectToAction("Index");

                }

                foreach(var error in result.Errors)
                {

                    ModelState.AddModelError("", error.Description);
                }
            }
          
            foreach (var user in UserManager.Users)
            {
                if (await UserManager.IsInRoleAsync(user, role.Name))
                { model.Users.Add(user.UserName); }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await RoleManager.FindByIdAsync(roleId);
            if(role == null)
            {
                ViewBag.ErrorMessage = $"ROle with Id = {roleId} cannot be found";
                return View("NotFound");
            }
            var model = new List<UserRoleViewModel>();
            foreach(var user in UserManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName

                };
                if(await UserManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }
                model.Add(userRoleViewModel);
            }
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model,string roleId)
        {
            var role = await RoleManager.FindByIdAsync(roleId);
            if(role == null)
            {
                ViewBag.ErrorMessage = $"ROle with Id = {roleId} cannot be found";
                return View("NotFound");
            }
            for(int i = 0; i <model.Count; i++)
            { var user = await UserManager.FindByIdAsync(model[i].UserId);
                IdentityResult result = null;
                if (model[i].IsSelected && !( await UserManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await UserManager.AddToRoleAsync(user, role.Name);

                }
                else if(!model[i].IsSelected && (await UserManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await UserManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
                if(result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }

            }
            return RedirectToAction("EditRole", new { Id = roleId });
        }
    }
}
