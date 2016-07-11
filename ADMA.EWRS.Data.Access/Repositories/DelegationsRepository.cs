//Murad :: Info : Must ADD referance to Entity and Linq to see the extension methods
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ADMA.EWRS.Data.Models.Repositories;
using ADMA.EWRS.Data.Models;
using ADMA.EWRS.Data.Models.Data;

namespace ADMA.EWRS.Data.Access.Repositories
{
    public class DelegationsRepository : Repository<Delegation, EWRSContext>, IDelegationsRepository
    {
        public DelegationsRepository(EWRSContext context)
            : base(context)
        {
        }

        public IEnumerable<Delegation> GetUserDelegation(int userId)
        {
            return DbContext.Delegations.Where(d => d.User_Id == userId && d.FromDate <= DateTime.Today && d.ToDate >= DateTime.Today );
        }
    }
}
