using ADMA.EWRS.Data.Access;
using ADMA.EWRS.Data.Models;
using ADMA.EWRS.Data.Models.Security;
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
