using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ADMA.EWRS.BizDomain;
using ADMA.EWRS.Data.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ADMA.EWRS.Web.Core.Controllers
{
    //[Authorize(Policy = PolicyNames.SuperAdministrators)]
    public class MuradController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Murad> mManagerData = new MuradManager().GetTopMuradies(5).ToList();
            return View(mManagerData);
        }
    }
}
