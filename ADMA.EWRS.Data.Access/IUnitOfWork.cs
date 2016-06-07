using ADMA.EWRS.Data.Access.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Access
{
    public interface IUnitOfWork : IDisposable
    {
        IMuradRepository Muradies { get; }
        int Save();
    }
}
