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

    }
}
