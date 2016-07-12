using ADMA.EWRS.BizDomain;
using ADMA.EWRS.Data.Models;
using ADMA.EWRS.Data.Models.Security;
using ADMA.EWRS.Data.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADMA.EWRS.Web.Core.ViewComponents
{
    //Murad :: Note
    //View component classes can be contained in any folder in the project.

    //See : https://docs.asp.net/en/latest/mvc/views/view-components.html
    //The [ViewComponent] attribute can change the name used to reference a view component. For example, we could have named the 
    //class XYZ, and applied the ViewComponent attribute:
    public class ProjectInfoWizardStepViewComponent : ViewComponent
    {
        private IServiceProvider _provider;
        private IClaimsSecurityManager _claimsSecurityManager;
        private LoggedInUser _currentUser;
        private ProjectsManager _pm;

        public ProjectInfoWizardStepViewComponent(IServiceProvider provider, IClaimsSecurityManager claimsSecurityManager)
        {
            _provider = provider;
            _claimsSecurityManager = claimsSecurityManager;
            //_claimsSecurityManager = _provider.GetService<IClaimsSecurityManager>();
            _currentUser = _claimsSecurityManager.CurrentUser;
            _pm = new ProjectsManager(_provider);
        }

        public async Task<IViewComponentResult> InvokeAsync(int projectId)
        {
            ProjectInfoWizardStepView projView;
            if (projectId > 0)
            {
                var projectItem = _pm.GetProject(projectId); //await GetItemsAsync(maxPriority, isDone);
                projView = new ProjectInfoWizardStepView()
                {
                    Name = projectItem.Name,
                    Description = projectItem.Description,
                    Project_Id = projectItem.Project_Id,
                    ORGANIZATION_ID = projectItem.ORGANIZATION_ID
                };
            }
            else
                projView = new ProjectInfoWizardStepView();

            //Build the Organization path
            projView.OrganizationHierarchyTree = new OrganizationsManager(_provider).ResolveOrganizationHierarchy(_currentUser.ORGANIZATION_ID).OrderBy(o => o.Sort).ToList();

            return View("~/Views/Project/Components/ProjectInfoWizardStep.cshtml", projView);

        }


        //private Task<List<Project>> GetItemsAsync(int maxPriority, bool isDone)
        //{
        //    return await _pm.GetProjects(_currentUser.UserId, null);
        //    //return db.ToDo.Where(x => x.IsDone == isDone &&
        //    //                     x.Priority <= maxPriority).ToListAsync();
        //}

    }
}
