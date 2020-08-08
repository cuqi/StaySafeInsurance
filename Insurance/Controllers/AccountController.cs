using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using Insurance.Models;
using Insurance.ViewModels;
using Insurance.Data;

namespace Insurance.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<Account> userManager;
        private SignInManager<Account> signInManager;
        private IPasswordHasher<Account> passwordHasher;
        private IPasswordValidator<Account> passwordValidator;
        private IUserValidator<Account> userValidator;
        private readonly InsuranceContext _context;

        public AccountController(UserManager<Account> userMgr, SignInManager<Account> signinMgr, IPasswordHasher<Account> passwordHash, IPasswordValidator<Account> passwordValid, IUserValidator<Account>
            userValid, InsuranceContext context)
        {
            userManager = userMgr;
            signInManager = signinMgr;
            passwordHasher = passwordHash;
            passwordValidator = passwordValid;
            userValidator = userValid;
            _context = context;
        }
        /*public IActionResult Index()
        {
            return View();
        }*/
    
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            LoginViewModel login = new LoginViewModel();
            login.ReturnUrl = returnUrl;
            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                Account account = await userManager.FindByEmailAsync(login.Email);
                if (account != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(account, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        if ((await userManager.IsInRoleAsync(account, "Admin")))
                        {
                            //return Redirect(login.ReturnUrl ?? "/");
                            return RedirectToAction("Index", "Agents", null);
                        }
                        if ((await userManager.IsInRoleAsync(account, "User")))
                        {
                            return RedirectToAction("Index", "Users", new { id = account.UserId });
                        }
                        if ((await userManager.IsInRoleAsync(account, "Agent")))
                        {
                            return RedirectToAction("Index", "Agents", new { id = account.AgentId });
                        }
                    }
                }
                ModelState.AddModelError(nameof(login.Email), "Login Failed: Invalid Email or password");
            }
            return View(login);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", null);
        }

    }
}