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
    public class TemplateWizardStepViewComponent : ViewComponent
    {
        private IServiceProvider _provider;
        private IClaimsSecurityManager _claimsSecurityManager;
        private LoggedInUser _currentUser;
        private ProjectsManager _pm;

        public TemplateWizardStepViewComponent(IServiceProvider provider, IClaimsSecurityManager claimsSecurityManager)
        {
            _provider = provider;
            _claimsSecurityManager = claimsSecurityManager;
            //_claimsSecurityManager = _provider.GetService<IClaimsSecurityManager>();
            _currentUser = _claimsSecurityManager.CurrentUser;
            _pm = new ProjectsManager(_provider);
        }

        public async Task<IViewComponentResult> InvokeAsync(int projectId)
        {
            Template temp = _pm.GetTemplateOrDefualt(projectId);
            TemplateWizardStepView tempView = temp.TransformToTemplateWizardStepView();

            //tempView = new TemplateWizardStepView()
            //{
            //    Name = temp.Name,
            //    Project_Id = temp.Project_Id,
            //    Template_Id = temp.Template_Id,
            //    Subjects = temp.Subjects.Select(s => new SubjectWizardStepView()
            //    {
            //        Template_Id = s.Template_Id,
            //        Subject_Id = s.Subject_Id,
            //        Name = s.Name,
            //        IsMandatory = s.IsMandatory,
            //        DueDate = s.DueDate,
            //        SequenceNo = s.SequenceNo
            //    }).ToList()
            //};

            return View("~/Views/Project/Components/TemplateWizardStep.cshtml", tempView);
        }

        //private Task<List<Project>> GetItemsAsync(int maxPriority, bool isDone)
        //{
        //    return await _pm.GetProjects(_currentUser.UserId, null);
        //    //return db.ToDo.Where(x => x.IsDone == isDone &&
        //    //                     x.Priority <= maxPriority).ToListAsync();
        //}

    }
}
