﻿using ADMA.EWRS.Data.Models.Security;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ADMA.EWRS.Data.Models.ViewModel;

namespace ADMA.EWRS.Web.Core.Controllers
{
    public class BaseWebController : Controller
    {
        private IServiceProvider _provider;
        private IClaimsSecurityManager _claimsSecurityManager;

        private LoggedInUser _currentUser;

        public LoggedInUser CurrentUser { get { return _currentUser; } }

        public BaseWebController(bool LoginService)
        {

        }

        public BaseWebController(IServiceProvider provider)
        {
            _provider = provider;
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
    }
}
