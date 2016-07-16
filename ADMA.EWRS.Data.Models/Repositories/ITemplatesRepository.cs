using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.Repositories
{
    public interface ITemplatesRepository : IRepository<Template>
    {
        Template GetTemplate(int projectId);
    }
}
