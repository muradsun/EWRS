﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ADMA.EWRS.Web.Core.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Forbidden()
        {
            return View();
        }

        // GET: /<controller>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login()
        {

            return View();
        }
    }
}
