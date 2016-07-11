using ADMA.EWRS.Data.Models.ViewModel;
using ADMA.EWRS.Web.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADMA.EWRS.Web.Core.Filters
{
    public class AppFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as BaseController;
            if (controller == null) return;

            string controllerName = context.RouteData.Values["controller"].ToString();
            if (!controllerName.Equals("Account"))
                controller.ViewBag.PageInfo = new PageInfo(controller.CurrentUser)
                {
                    Title = "Welcome to Corporate Weekly Report System",
                    Description = "Version 1.0",
                };

        }
    }
}
