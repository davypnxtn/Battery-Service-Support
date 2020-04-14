using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Battery_Service_Support.Controllers
{
    [Authorize(Roles="Beheerder, Administrator")]
    public class AdministrationController : Controller
    {
        private readonly IAdministrationService service;

        public AdministrationController(IAdministrationService _service)
        {
            service = _service;
        }

        [HttpGet]
        [Authorize(Roles = "Beheerder")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Beheerder")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await service.CreateRole(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = service.GetRoles();
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            EditRoleViewModel model = await service.CreateEditRoleViewModel(id);

            if (!string.IsNullOrEmpty(model.ErrorMessage))
            {
                ViewData["ErrorMessage"] = model.ErrorMessage;
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await service.EditRole(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityResult result = await service.DeleteRole(id);

            if (result.Succeeded)
            {
                return RedirectToAction("ListRoles");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View("ListRoles");
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewData["roleId"] = roleId;

            var model = await service.CreateRoleUsersViewModel(roleId);

            if (!string.IsNullOrEmpty(model[0].ErrorMessage))
            {
                ViewData["ErrorMessage"] = model[0].ErrorMessage;
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUsersInRole(List<RoleUsersViewModel> model, string roleId)
        {
            string errorMessage = await service.EditUsersInRole(model, roleId);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                ViewData["ErrorMessage"] = errorMessage;
                return View("NotFound");
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = service.ListUsers();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            EditUserViewModel model = await service.CreateEditUserViewModel(id);

            if (!string.IsNullOrEmpty(model.ErrorMessage))
            {
                ViewData["ErrorMessage"] = model.ErrorMessage;
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await service.EditUser(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string id)
        {
            IdentityResult result = await service.DeleteUser(id);

            if (result.Succeeded)
            {
                return RedirectToAction("ListUsers");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View("ListUsers");
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string UserId)
        {
            ViewData["userId"] = UserId;

            var model = await service.CreateUserRolesViewModel(UserId);

            if (!string.IsNullOrEmpty(model[0].ErrorMessage))
            {
                ViewData["ErrorMessage"] = model[0].ErrorMessage;
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageUserRoles(List<UserRolesViewModel> model, string userId)
        {
            string errorMessage = await service.ManageUserRoles(model, userId);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                ViewData["ErrorMessage"] = errorMessage;
                return View("NotFound");
            }

            return RedirectToAction("EditUser", new { Id = userId });
        }
    }
}
