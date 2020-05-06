using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Battery_Service_Support.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService service;

        public AccountController(IAccountService _service)
        {
            service = _service;
        }

        [HttpGet]
        [Authorize(Roles = "Beheerder, Administrator")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Beheerder, Administrator")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await service.Register(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers", "Administration");
                }
                
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            service.Logout();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                
                var (result, isAdmin) = await service.Login(model);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        if (isAdmin)
                        {
                            return RedirectToAction("BatterieWarningList", "Batterij");
                        }
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        if (isAdmin)
                        {
                            return RedirectToAction("BatterieWarningList", "Batterij");
                        }
                        return RedirectToAction("Index", "Relatie");
                    }
                }

                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError(string.Empty, "Account Is Not Activated. Contact Support");
                }
                else if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Account Is locked! To Many Login Attempts");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
