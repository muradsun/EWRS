using ADMA.EWRS.Data.Models;
using ADMA.EWRS.Data.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Access.Repositories
{
    public class SubjectsRepository : Repository<Subject, EWRSContext>, ISubjectsRepository
    {
        public SubjectsRepository(EWRSContext context)
          : base(context)
        {

        }
        public Subject GetSubject(int subjectId)
        {
            return DbContext.Subjects.Where(t => t.Subject_Id == subjectId).FirstOrDefault();
        }

    }
}