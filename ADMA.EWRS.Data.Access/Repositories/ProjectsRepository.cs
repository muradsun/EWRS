//Murad :: Info : Must ADD referance to Entity and Linq to see the extension methods
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ADMA.EWRS.Data.Models.Repositories;
using ADMA.EWRS.Data.Models;


namespace ADMA.EWRS.Data.Access.Repositories
{
    public class ProjectsRepository : Repository<Project, EWRSContext>, IProjectsRepository
    {
        public ProjectsRepository(EWRSContext context)
            : base(context)
        {

        }

        public IEnumerable<Project> GetAllProjects(int Owner_UserId, List<int> Delegated_UsersList)
        {
            if (Delegated_UsersList != null)
                return DbContext.Projects.Where(
                    p =>
                        p.Owner_UserId == Owner_UserId ||
                       Delegated_UsersList.Contains(p.Owner_UserId)
                 );
            else
                return DbContext.Projects.Where(p => p.Owner_UserId == Owner_UserId);
        }

        public IEnumerable<Project> GetTopNProjects(int count)
        {
            return DbContext.Projects.Take(count);

        }

        public bool MarkSaveProject(Project project)
        {
            if (project.Project_Id == 0)
                //Make ADD
                DbContext.Projects.Add(project);
            else
                //Attach the entity 
                DbContext.Entry(project).State = EntityState.Modified;

            return true;
        }
    }
}
