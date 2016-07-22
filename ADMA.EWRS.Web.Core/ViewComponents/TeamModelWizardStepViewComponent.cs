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
    public class TeamModelWizardStepViewComponent : ViewComponent
    {
        private IServiceProvider _provider;
        private IClaimsSecurityManager _claimsSecurityManager;
        private LoggedInUser _currentUser;
        private ProjectsManager _pm;

        public TeamModelWizardStepViewComponent(IServiceProvider provider, IClaimsSecurityManager claimsSecurityManager)
        {
            _provider = provider;
            _claimsSecurityManager = claimsSecurityManager;
            //_claimsSecurityManager = _provider.GetService<IClaimsSecurityManager>();
            _currentUser = _claimsSecurityManager.CurrentUser;
            _pm = new ProjectsManager(_provider);
        }

        public async Task<IViewComponentResult> InvokeAsync(int projectId)
        {
            List<TeamModel> team = _pm.GetTeamModelOrDefualt(projectId);
            uint seq = 0;
            return View("~/Views/Project/Components/TeamModelWizardStep.cshtml",
                    team.Select(t => new TeamModeWizardStepView()
                    {
                        Group_Id = t.Group_Id,
                        User_Id = t.User_Id,
                        IsUpdater = t.IsUpdater,
                        Project_Id = t.Project_Id,
                        TeamModel_Id = t.TeamModel_Id,
                        SequenceNo = ++seq
                    }).ToList<TeamModeWizardStepView>()
                );
        }

        //private Task<List<Project>> GetItemsAsync(int maxPriority, bool isDone)
        //{
        //    return await _pm.GetProjects(_currentUser.UserId, null);
        //    //return db.ToDo.Where(x => x.IsDone == isDone &&
        //    //                     x.Priority <= maxPriority).ToListAsync();
        //}

    }
}
