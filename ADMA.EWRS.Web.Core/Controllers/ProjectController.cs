using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ADMA.EWRS.Data.Models.ViewModel;
using ADMA.EWRS.BizDomain;
using Newtonsoft.Json;
using ADMA.EWRS.Data.Models;
using Microsoft.AspNetCore.Authorization;
using ADMA.EWRS.Security.Policy;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ADMA.EWRS.Web.Core.Controllers
{
    public class ProjectController : BaseController
    {
        ProjectsManager _pm;
        public ProjectController(IServiceProvider provider)
            : base(provider)
        {
            _pm = new ProjectsManager(provider);
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            PageInfoData.Title = "Projects List";
            PageInfoData.Description = "List of Projects created by you and delegated to you";
            //PageInfoData.Breadcrumb.Add(new Breadcrumb { Text = @"<i class='fa fa - leanpub margin-right-5 text-large text-dark'></i> Dashboard", Link = null });
            PageInfoData.Breadcrumbs.Add(new Breadcrumb { Text = "Projects List", Link = null });

            //Get List of the projects created by logged in user and his delegated users
            var projectsList = _pm.GetProjects(CurrentUser.UserId, CurrentUser.DelegationSet);
            return View(projectsList);
        }

        [Authorize(Policy = PolicyNames.ProjectOwners)]
        public IActionResult CreateProjectWizard()
        {
            PageInfoData.Title = "Project Configurations Wizard";
            PageInfoData.Description = "Use this Wizard to configure a Project, Project Template, Team Model and Review Workflow";
            //PageInfoData.Breadcrumb.Add(new Breadcrumb { Text = @"<i class='fa fa - leanpub margin-right-5 text-large text-dark'></i> Dashboard", Link = null });
            PageInfoData.Breadcrumbs.AddRange(new List<Breadcrumb>() {
                    new Breadcrumb { Text = "Projects List", Link = "/Project" },
                    new Breadcrumb { Text = "Project Wizard", Link = null },
                });

            ViewBag.ProjectId = 0;

            return View();
        }

        #region Web API
        /// <summary>
        /// Save the first step in Project Configuration Wizard
        /// </summary>
        /// <param name="projectInfoWizardStepView"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveProjectWizardStep([FromBody] ProjectInfoWizardStepView projectInfoWizardStepView)
        {
            //Create Project Entity and send for Save
            Project ptoj = new Project()
            {
                Project_Id = projectInfoWizardStepView.Project_Id,
                Name = projectInfoWizardStepView.Name,
                Description = projectInfoWizardStepView.Description,
                ORGANIZATION_ID = projectInfoWizardStepView.ORGANIZATION_ID,

                CreatedBy = CurrentUser.UserId.ToString(),
                CreatedDate = DateTime.Now,
                Owner_UserId = CurrentUser.UserId,

            };

            //If new Project then it is Draft 
            if (projectInfoWizardStepView.Project_Id == 0)
            {
                ptoj.ProjectStatus_Id = Data.Models.Enums.ProjectStatusEnum.Draft;
                ptoj.PercentComplete = 0;
            }

            if (_pm.SaveProject(ptoj))
                return GetJSONResult(ptoj.Project_Id);
            else
                return GetJSONResult(ptoj.Project_Id, false, _pm.BusinessErrors);
        }

        [HttpPost]
        public JsonResult SaveTemplateWizardStep([FromBody] TemplateWizardStepView templateWizardStepView)
        {
            return Json(new { ok = true });
        }

        public JsonResult SearchOrganizationHierarchy(string filter)
        {
            var orgList = _pm.SearchOrganizationHierarchy(filter);
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

            return GetJSON(data);
        }

        #endregion

    }
}
