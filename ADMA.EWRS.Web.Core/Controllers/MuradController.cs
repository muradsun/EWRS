using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ADMA.EWRS.BizDomain;
using ADMA.EWRS.Data.Models;
using Microsoft.AspNetCore.Authorization;
using ADMA.EWRS.Security.Policy;
using System;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ADMA.EWRS.Web.Core.Controllers
{
    //[Authorize(Policy = PolicyNames.SuperAdministrators)]
    //[Authorize(Policy = PolicyNames.SuperAdministrators)]
   
    public class MuradController : BaseController
    {
        public MuradController(IServiceProvider provider)
            : base(provider)
        {

        }


        //[Authorize(Policy = "Ali")]
        // GET: /<controller>/
        public IActionResult Index()
        {
            var username = CurrentUser.GivenName;

            //List<Murad> mManagerData = new MuradManager().GetTopMuradies(5).ToList();
            return View();
           
            //return View(mManagerData);
        }

        [Authorize(Policy = PolicyNames.SuperAdministrators)]
        public IActionResult AccessX()
        {
            //List<Murad> mManagerData = new MuradManager().GetTopMuradies(5).ToList();
            return View();

            //return View(mManagerData);
        }
    }
}
