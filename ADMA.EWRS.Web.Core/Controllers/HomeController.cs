using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADMA.EWRS.Data.Models.Security;
using Microsoft.AspNetCore.Mvc;

namespace ADMA.EWRS.Web.Core.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IServiceProvider provider)
            : base(provider)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
