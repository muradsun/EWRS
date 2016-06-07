using ADMA.EWRS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ADMA.EWRS.Data.Access.Repositories
{
    public class MuradRepository : Repository<Murad>, IMuradRepository
    {
        public MuradRepository(EWRSContext context)
            : base(context)
        {

        }

        public IEnumerable<Murad> GetTopMurad(int count)
        {
            return EwrsContext.Muradies.Take(count).ToList();
        }

        public EWRSContext EwrsContext
        {
            get { return Context as EWRSContext; }
        }

    }
}
