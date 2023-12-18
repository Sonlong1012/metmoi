﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using Webbanhang_22011267.Models;
using Webbanhang_22011267.Data;

namespace Webbanhang_22011267.Controllers
{
    public class UserController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        //private readonly IUserStore<IdentityUser> _userStore;
        //private readonly IUserEmailStore<IdentityUser> _emailStore;
        //private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;

        private readonly AppDBContext _dbContext;
        public UserController(AppDBContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {

            this._dbContext = context;
            _signInManager = signInManager;
            _userManager = userManager;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel usermodel)
        {
            string returnUrl = ""; //Url.Content("~/");
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                user.FristName = usermodel.FirstName;
                user.LastName = usermodel.LastName;
                user.UserName = usermodel.Email;
                user.Email = usermodel.Email;
                user.Address = usermodel.Address;
                user.PhoneNumber = usermodel.Phone;

                // await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                // await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, usermodel.Password);

                if (result.Succeeded)
                {
                    // _logger.LogInformation("User created a new account with password.");

                    //var userId = await _userManager.GetUserIdAsync(user);
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = usermodel.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel usermodel)
        {
            string returnUrl = "~/Home/Index";

            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

         if (ModelState.IsValid)
        {

            var result = await _signInManager.PasswordSignInAsync(usermodel.Email, usermodel.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
               
                return LocalRedirect(returnUrl);
            }
            
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }
        }
        return View();
        }
    

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            await _signInManager.SignOutAsync();
            //_logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // This needs to be a redirect so that the browser performs a new
                // request and the identity for the user gets updated.
                return RedirectToAction("Index","Home");
            }
        }


        public AppUser CreateUser()
            {
                try
                {
                    return Activator.CreateInstance<AppUser>();
                }
                catch
                {
                    throw new InvalidOperationException($"Can't create an instance of '{nameof(AppUser)}'. " +
                        $"Ensure that '{nameof(AppUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                        $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
                }
            }
    }
}
