using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.Repositories
{
    public interface ISubjectsRepository : IRepository<Subject>
    {
        Subject GetSubject(int subjectId);
    }
}
