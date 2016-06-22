using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.Repositories
{
    public interface IProjectsRepository : IRepository<Project>
    {
        IEnumerable<Project> GetTopNProjects(int count);
    }
}
