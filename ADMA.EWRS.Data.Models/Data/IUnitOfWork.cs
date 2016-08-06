using ADMA.EWRS.Data.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IMuradRepository Muradies { get; }
        IUsersRepository Users { get; }
        int Save();
    }
}
