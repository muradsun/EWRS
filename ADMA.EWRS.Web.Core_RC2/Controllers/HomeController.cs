using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADMA.EWRS.Data.Models.Security;
using Microsoft.AspNetCore.Mvc;
using ADMA.EWRS.Data.Models.ViewModel;

namespace ADMA.EWRS.Web.Core.Controllers
{
    public class HomeController : BaseWebController
    {
        public HomeController(IServiceProvider provider)
            : base(provider)
        {
          
        }

        public IActionResult Index()
        {
            PageInfoData.Title = "Welcome to Corporate Weekly Report System";
            PageInfoData.Description = "Version 1.0";
            //PageInfoData.Breadcrumb.Add(new Breadcrumb { Text = @"<i class='fa fa - leanpub margin-right-5 text-large text-dark'></i> Dashboard", Link = null });
            PageInfoData.Breadcrumb.Add(new Breadcrumb { Text = "Dashboard", Link = null });
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
