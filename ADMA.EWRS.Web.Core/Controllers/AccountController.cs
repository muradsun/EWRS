﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ADMA.EWRS.BizDomain;
using ADMA.EWRS.Data.Models;
using ADMA.EWRS.Web.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using ADMA.EWRS.Data.Models.ViewModel;
using ADMA.EWRS.Data.Models.ModelView;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ADMA.EWRS.Web.Core.Controllers
{
    public class AccountController : BaseController
    {
        private SecurityManager _secManager;
        private ClaimsManager _claimsManager;
        private IServiceProvider _provider;

        //public AccountController()
        //{

        //}

        //public AccountController()
        //   : base(true)
        public AccountController(IServiceProvider provider)
            : base(provider, true)
        {
            _secManager = new SecurityManager();
            _claimsManager = new ClaimsManager();
            _provider = provider;
        }

        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Forbidden()
        {
            @ViewBag.Title = "Forbidden";
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            string nameClaim = ClaimsManager.ExtractNameClaimFromCurrentContext(HttpContext);
            User user = _claimsManager.GetUserFromNameClaim(nameClaim);
            if (user == null)
            {
                //return HttpUnauthorized(); //HttpResponseException(HttpStatusCode.Unauthorized);
                //ContentResult
                //EmptyResult
                //FileResult
                //HttpStatusCodeResult
                //JavaScriptResult
                //JsonResult
                //RedirectResult
                //RedirectToRouteResult

                return RedirectToAction("Forbidden"); //Murad :: See -> https://docs.asp.net/en/latest/migration/rc1-to-rc2.html?highlight=httpstatuscoderesult
            }
            else
            {
                //Build Claim Base principal 
                var userPrincipal = _claimsManager.CreateClaimsPrincipal(user);

                //HttpContext.User = userPrincipal;

                await HttpContext.Authentication.SignInAsync(
                    ADMA.EWRS.Web.Security.Cookies.AuthenticationCookieName, userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddDays(7),
                        IsPersistent = true,
                        AllowRefresh = false
                    });

                return RedirectToLocal(returnUrl);
            }
        }

        [HttpPost]
        public JsonResult SearchUsers([FromBody] UsersSearchRequestView usersSearchRequestView)
        {
            ProjectsManager _pm = new ProjectsManager(_provider);
            int recordsCount = 0;
            List<User> searchUsers = _secManager.SearchUsers(usersSearchRequestView, usersSearchRequestView.PageIndex, ref recordsCount);
            List<UsersSearchResponseView> response = searchUsers.Select(u => new UsersSearchResponseView()
            {
                Email = u.EMAIL,
                EmployeeName = u.EMPLOYEE_NAME,
                PFNo = u.PF_NO,
                Title = u.POST_TITLE_LONG_DESC,
                User_Id = u.User_Id,
                OrganizationId = u.ORGANIZATION_ID,
                OrganizationHierarchyText = _pm.GetOrganizationHierarchy(u.ORGANIZATION_ID).TransformToAutoCompleteView(),
                Gender = u.GENDER,
            }).ToList();

            var responseView = new DataPagingResponseView() { Data = response, Count = recordsCount };
            return GetJSON(responseView);
        }

        [HttpPost]
        public JsonResult SearchGroups([FromBody] GroupsSearchRequestView groupsSearchRequestView)
        {
            base.RebuildClaims();
            int recordsCount = 0;

            List<ADMA.EWRS.Data.Models.Group> searchUsers = _secManager.SearchGroups(groupsSearchRequestView.Name, CurrentUser.UserId, groupsSearchRequestView.PageIndex, ref recordsCount);
            List<GroupsSearchResponseView> response = searchUsers.Select(g => new GroupsSearchResponseView()
            {
                Group_Id = g.Group_Id,
                Name = g.Name,
                Users = g.GroupUsers.Select(u => u.User.EMPLOYEE_NAME).ToList<string>(),
            }).ToList();

            var responseView = new DataPagingResponseView() { Data = response, Count = recordsCount };
            return GetJSON(responseView);
        }

        public IActionResult SearchUsersGroups()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }


    }
}
