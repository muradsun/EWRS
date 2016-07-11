using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ADMA.EWRS.BizDomain;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ADMA.EWRS.Web.Core.Controllers
{
    public class MYasinController : BaseWebController
    {
        public MYasinController(IServiceProvider provider)
            : base(provider)
        {

        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Adnan()
        {
            ViewBag.Title = "Adnana Man";
            ViewBag.ActiveLeftMenuLink = "Layout";

            return View();
        }


        public IActionResult TopN()
        {
            ProjectsManager pMan = new ProjectsManager();
            var x = pMan.ProcessTopNRecordes(2); 

            return View();
        }

    }
}
