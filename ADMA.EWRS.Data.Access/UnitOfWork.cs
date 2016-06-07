using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMA.EWRS.Data.Access.Repositories;

namespace ADMA.EWRS.Data.Access
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EWRSContext _context;

        public UnitOfWork(EWRSContext context)
        {
            _context = context;
            Muradies = new MuradRepository(_context);
        }

        public IMuradRepository Muradies { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
