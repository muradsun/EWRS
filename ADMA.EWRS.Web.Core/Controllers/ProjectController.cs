using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ADMA.EWRS.Data.Models.ViewModel;
using ADMA.EWRS.BizDomain;
using Newtonsoft.Json;

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

        public JsonResult SearchOrganizationHierarchy(string filter)
        {
            var orgList = pm.SearchOrganizationHierarchy(filter);
            var data = orgList.Select(o => new OrganizationHierarchyAutoCompleteView()
            {
                ORGID = o.ORGID,
                ORGNAME = o.ORGNAME,

                BU_NAME = o.BU_NAME,
                DIV_NAME = o.DIV_NAME,
                DEP_NAME = o.DEP_NAME,
                TEAM_NAME = o.TEAM_NAME,
                SECTION_NAME = o.SECTION_NAME
            });

            return Json(data, new JsonSerializerSettings()
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() //Murad : TODO :: CHnage this to lower 
            });

        }

        /// <summary>
        /// Save the first step in Project Configuration Wizard
        /// </summary>
        /// <param name="projectInfoWizardStepView"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveProjectWizardStep([FromBody] ProjectInfoWizardStepView projectInfoWizardStepView)
        {
            return Json(new { Ok = true });
        }

        [HttpPost]
        public IActionResult SaveTemplateWizardStep([FromBody] TemplateWizardStepView templateWizardStepView)
        {
            return Json(new { Ok = true });
        }



    }
}
