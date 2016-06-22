//Murad :: Info : Must ADD referance to Entity and Linq to see the extension methods
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ADMA.EWRS.Data.Models.Repositories;
using ADMA.EWRS.Data.Models;


namespace ADMA.EWRS.Data.Access.Repositories
{
    public class MuradRepository : Repository<Murad, EWRSContext>, IMuradRepository
    {
        public MuradRepository(EWRSContext context)
            : base(context)
        {

        }

        public IEnumerable<Murad> GetTopMurad(int count)
        {
            return null;  //EwrsContext.Muradies.Take(count).ToList();
        }
       
    }
}
