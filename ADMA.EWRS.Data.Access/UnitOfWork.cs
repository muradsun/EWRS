using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMA.EWRS.Data.Access.Repositories;
using ADMA.EWRS.Data.Models.Data;
using ADMA.EWRS.Data.Models.Repositories;

namespace ADMA.EWRS.Data.Access
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EWRSContext _context;

        public UnitOfWork()
        {
            _context = new ADMA.EWRS.Data.Access.EWRSContext();

            //Murad :: TODO : Replace with Murad Db Logger...
            _context.Database.Log = Console.Write;

            Muradies = new MuradRepository(_context);
            Users = new UserRepository(_context);
            Projects = new ProjectsRepository(_context);
            Groups = new GroupsRepository(_context);
            Permissions = new PermissionsRepository(_context);
        }

        public IMuradRepository Muradies { get; private set; }
        public IUserRepository Users { get; private set; }
        public IProjectsRepository Projects { get; private set; }
        public IGroupsRepository Groups { get; private set; }
        public IPermissionsRepository Permissions { get; private set; }

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
