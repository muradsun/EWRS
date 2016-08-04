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
        private UnitOfWork UnitOfWork { get { return base._unitOfWork; } }

        public ProjectsManager(IServiceProvider _provider)
            : base(_provider)
        {
            BusinessErrors = Enumerable.Empty<ADMA.EWRS.Data.Models.Validation.ValidationError>();
        }

        public ProjectsManager(IServiceProvider _provider, UnitOfWork unitOfWork)
            : base(_provider, unitOfWork)
        {
            BusinessErrors = Enumerable.Empty<ADMA.EWRS.Data.Models.Validation.ValidationError>();
        }


        public List<Project> GetProjects(int Owner_UserId, List<int> Delegated_UsersList)
        {
            return UnitOfWork.Projects.GetAllProjects(Owner_UserId, Delegated_UsersList).ToList();
        }

        public Project GetProject(int projectId)
        {
            return UnitOfWork.Projects.Find(p => p.Project_Id == projectId).FirstOrDefault();
        }

        public Template GetTemplateOrDefualt(int projectId)
        {
            if (projectId == 0)
                return GetDefualtTemplate(projectId);
            else
            {
                var temp = UnitOfWork.Templates.GetTemplate(projectId);
                if (temp != null)
                    return temp;
                else
                    return GetDefualtTemplate(projectId);
            }
        }

        public List<TeamModel> GetTeamModelOrDefualt(int projectId)
        {
            if (projectId == 0)
                return new List<TeamModel>();
            else
                return UnitOfWork.TeamModel.GetTeamModel(projectId).ToList();
        }

        public List<OrganizationHierarchy> SearchOrganizationHierarchy(string orgName)
        {
            var escapOrgTypes = new List<string>(new string[] { "TC", "BG", null });
            return UnitOfWork.OrganizationHierarchies.Find(o => o.ORGNAME.Contains(orgName) && !escapOrgTypes.Contains(o.ORGTYPE)).ToList();
        }

        public OrganizationHierarchy GetOrganizationHierarchy(int orgId)
        {
            return UnitOfWork.OrganizationHierarchies.Find(o => o.ORGID == orgId).FirstOrDefault();
        }
        public bool SaveProject(Project project)
        {
            try
            {
                UnitOfWork.Projects.MarkSaveProject(project);

                var engine = new ProjectsEngine();
                //Make Validation//
                var errors = engine.Validate(project, UnitOfWork);
                if (errors != null && errors.Count() > 0)
                {
                    base.BusinessErrors = errors;
                    return false;
                }

               
                UnitOfWork.Save();

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

        private Template GetDefualtTemplate(int projectId)
        {
            return new Template()
            {
                Project_Id = projectId,
                Name = "Default Template",
                Subjects = new List<Subject>() {
                    new Subject() { Name = "Progress", IsMandatory= true, DueDate = null , SequenceNo = 1, Project_Id = projectId},
                    new Subject() { Name = "Planning", IsMandatory= true, DueDate = null , SequenceNo = 2,  Project_Id = projectId},
                    new Subject() { Name = "Problems", IsMandatory= true, DueDate = null , SequenceNo = 3, Project_Id = projectId}
                }
            };
        }



        #endregion

    }
}
