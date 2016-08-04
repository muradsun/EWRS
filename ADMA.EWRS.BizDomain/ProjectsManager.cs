using ADMA.EWRS.BizDomain.Engine;
using ADMA.EWRS.Data.Access;
using ADMA.EWRS.Data.Models;
using ADMA.EWRS.Data.Models.Security;
using ADMA.EWRS.Data.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.BizDomain
{

    /// <summary>
    /// Manage the Project and the project related item such as Templates and Team Model
    /// </summary>
    public class ProjectsManager : BaseManager
    {
        public ProjectsManager(IServiceProvider _provider)
            : base(_provider)
        {
            BusinessErrors = Enumerable.Empty<ADMA.EWRS.Data.Models.Validation.ValidationError>();
        }

        public List<Project> GetProjects(int Owner_UserId, List<int> Delegated_UsersList)
        {
            using (var unitOfWork = new UnitOfWork())
                return unitOfWork.Projects.GetAllProjects(Owner_UserId, Delegated_UsersList).ToList();
        }

        public Project GetProject(int projectId)
        {
            using (var unitOfWork = new UnitOfWork())
                return unitOfWork.Projects.Find(p => p.Project_Id == projectId).FirstOrDefault();
        }

        public Template GetTemplateOrDefualt(int projectId)
        {
            if (projectId == 0)
                return GetDefualtTemplate();
            else
                using (var unitOfWork = new UnitOfWork())
                    return unitOfWork.Templates.GetTemplate(projectId);
        }

        public List<TeamModel> GetTeamModelOrDefualt(int projectId)
        {
            if (projectId == 0)
                return new List<TeamModel>();
            else
                using (var unitOfWork = new UnitOfWork())
                    return unitOfWork.TeamModel.GetTeamModel(projectId).ToList();
        }

        public List<OrganizationHierarchy> SearchOrganizationHierarchy(string orgName)
        {
            var escapOrgTypes = new List<string>(new string[] { "TC", "BG", null });
            using (var unitOfWork = new UnitOfWork())
                return unitOfWork.OrganizationHierarchies.Find(o => o.ORGNAME.Contains(orgName) && !escapOrgTypes.Contains(o.ORGTYPE)).ToList();
        }

        public static OrganizationHierarchy GetOrganizationHierarchy(int orgId)
        {
            using (var unitOfWork = new UnitOfWork())
                return unitOfWork.OrganizationHierarchies.Find(o => o.ORGID == orgId).FirstOrDefault();
        }
        public bool SaveProject(Project project)
        {
            try
            {
                var engine = new ProjectsEngine();
                //Save Data//
                using (var unitOfWork = new UnitOfWork())
                {
                    //Make Validation//
                    var errors = engine.Validate(project, unitOfWork);
                    if (errors != null && errors.Count() > 0)
                    {
                        base.BusinessErrors = errors;
                        return false;
                    }

                    unitOfWork.Projects.SaveProject(project);
                    unitOfWork.Save();
                }
                return true;
            }
            catch (Framework.ExceptionHandling.ValidationException ex)
            {
                //Business validation Error
                base.BusinessErrors = ex.ValidationErrors;
                return false;

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        #region Private Members 

        private Template GetDefualtTemplate()
        {
            return new Template()
            {
                Name = "Default Template",
                Subjects = new List<Subject>() {
                    new Subject() { Name = "Progress", IsMandatory= true, DueDate = null , SequenceNo = 1},
                    new Subject() { Name = "Planning", IsMandatory= true, DueDate = null , SequenceNo = 2},
                    new Subject() { Name = "Problems", IsMandatory= true, DueDate = null , SequenceNo = 3}
                }
            };
        }



        #endregion

    }
}
