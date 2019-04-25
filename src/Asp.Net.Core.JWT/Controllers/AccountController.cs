using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

using Asp.Net.Core.JWT.Services;
using Asp.Net.Core.JWT.Helpers;

namespace Asp.Net.Core.JWT.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : JMTController
    {

        public AccountController(IUserService userService) : base(userService)  {}

        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = _userService.Authenticate(model.User, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "username or password is invalid");
                    return View(model);
                }

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Token));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName));

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = model.RememberMe });

                return RedirectToLocal(returnUrl);
            }

              return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            var token = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
