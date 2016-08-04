using ADMA.EWRS.Data.Models.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ADMA.EWRS.Data.Models.ViewModel;
using Newtonsoft.Json;
using ADMA.EWRS.Data.Models.Validation;

namespace ADMA.EWRS.Web.Core.Controllers
{
    public class BaseController : Controller
    {
        private IServiceProvider _provider;
        private IClaimsSecurityManager _claimsSecurityManager;

        private LoggedInUser _currentUser;

        public LoggedInUser CurrentUser { get { return _currentUser; } }

        public BaseController(bool LoginService)
        {

        }

        public BaseController(IServiceProvider provider, bool isLogingRequest = false)
        {
            _provider = provider;
            if (isLogingRequest == false)
            {
                _claimsSecurityManager = _provider.GetService<IClaimsSecurityManager>();
                _currentUser = _claimsSecurityManager.CurrentUser;
            }
        }

        internal void RebuildClaims()
        {
            _claimsSecurityManager = _provider.GetService<IClaimsSecurityManager>();
            _currentUser = _claimsSecurityManager.CurrentUser;


        }

        public PageInfo PageInfoData { get { return ViewBag.PageInfo as PageInfo; } }

        //public BaseController()
        //{
        //    var test = DependencyResolver.Current.GetService<IClaimsSecurityManager>();
        //}

        internal IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        internal JsonResult GetJSON(object data)
        {
            return Json(data, new JsonSerializerSettings()
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() //Murad : TODO :: Change this to lower 
            });
        }


        internal JsonResult GetJSONResult(object data, bool isSuccess = true, IEnumerable<ValidationError> businessErrors = null)
        {
            var results = new JSONResultView() { Success = isSuccess, Data = data, BusinessErrors = businessErrors };
            return Json(results, new JsonSerializerSettings()
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() //Murad : TODO :: Change this to lower 
            });
        }
    }
}
