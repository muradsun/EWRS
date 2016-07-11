﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ADMA.EWRS.Data.Models.ViewModel;
using ADMA.EWRS.BizDomain;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ADMA.EWRS.Web.Core.Controllers
{
    public class ProjectController : BaseController
    {
        ProjectsManager pm;
        public ProjectController(IServiceProvider provider)
            : base(provider)
        {
            pm = new ProjectsManager(provider);
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            PageInfoData.Title = "Projects List";
            PageInfoData.Description = "List of Projects created by you and delegated to you";
            //PageInfoData.Breadcrumb.Add(new Breadcrumb { Text = @"<i class='fa fa - leanpub margin-right-5 text-large text-dark'></i> Dashboard", Link = null });
            PageInfoData.Breadcrumbs.Add(new Breadcrumb { Text = "Projects List", Link = null });

            //Get List of the projects created by logged in user and his delegated users
            var projectsList = pm.GetProjects(CurrentUser.UserId, CurrentUser.DelegationSet);
            return View(projectsList);
        }

        public IActionResult CreateProjectWizard()
        {
            PageInfoData.Title = "Project Configurations Wizard";
            PageInfoData.Description = "Use this Wizard to configure a Project, Project Template, Team Model and Review Workflow";
            //PageInfoData.Breadcrumb.Add(new Breadcrumb { Text = @"<i class='fa fa - leanpub margin-right-5 text-large text-dark'></i> Dashboard", Link = null });
            PageInfoData.Breadcrumbs.AddRange(new List<Breadcrumb>() {
                    new Breadcrumb { Text = "Projects List", Link = "/Project" },
                    new Breadcrumb { Text = "Project Wizard", Link = null },
                });

            return View();

        }

        public IActionResult ProjectInfoWizardStep(int projectId)
        {

            return View();
        }

    }
}
