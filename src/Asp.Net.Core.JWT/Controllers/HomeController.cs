using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Asp.Net.Core.JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Asp.Net.Core.JWT.Helpers;
using Asp.Net.Core.JWT.Services;

namespace Asp.Net.Core.JWT.Controllers
{
    public class HomeController : JMTController
    {

        public HomeController(IUserService userService) : base(userService) { }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
