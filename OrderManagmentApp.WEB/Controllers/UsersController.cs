using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OrderManagmentApp.WEB.Models;
using OrderManagmentApp.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Authorization;

using System.Collections.Generic;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace OrderManagmentApp.WEB.Controllers
{
    [Authorize(Roles ="admin")]
    public class UsersController : Controller
    {
        readonly UserManager<User> _userManager;
        readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index() => View(_userManager.Users.ToList());

        public IActionResult Create() => View(new CreateUserViewModel { AllRoles = _roleManager.Roles.ToList() });

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = model.Name};
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var resultAddRoles =  await _userManager.AddToRolesAsync(user, model.UserRoles);
                    if (resultAddRoles.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in resultAddRoles.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    } 
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { 
                Id = user.Id,
                Name = user.UserName,
                AllRoles = _roleManager.Roles.ToList(),
                UserRoles = await _userManager.GetRolesAsync(user)
            };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {                    
                    user.UserName = model.Name;                  

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);                        
                        //var allRoles = _roleManager.Roles.ToList();
                        var addedRoles = model.UserRoles.Except(userRoles);
                        var removedRoles = userRoles.Except(model.UserRoles);

                        await _userManager.AddToRolesAsync(user, addedRoles);
                        await _userManager.RemoveFromRolesAsync(user, removedRoles);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
    }
}