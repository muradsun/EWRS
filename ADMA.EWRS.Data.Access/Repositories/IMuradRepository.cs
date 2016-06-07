using ADMA.EWRS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Access.Repositories
{
    public interface IMuradRepository : IRepository<Murad>
    {
        IEnumerable<Murad> GetTopMurad(int count);
    }

}
