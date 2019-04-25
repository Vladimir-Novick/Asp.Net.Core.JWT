using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net.Core.JWT.Services;

namespace Asp.Net.Core.JWT.Helpers
{
    public class JMTController : Controller
    {
        public IUserService _userService;

        public JMTController(IUserService userService)
        {
            _userService = userService;
        }
    }
}
