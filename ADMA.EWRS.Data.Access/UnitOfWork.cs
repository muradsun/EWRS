using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMA.EWRS.Data.Access.Repositories;
using ADMA.EWRS.Data.Models.Data;
using ADMA.EWRS.Data.Models.Repositories;
using ADMA.EWRS.Data.Models;
using ADMA.EWRS.Data.Access.Utilities;
using ADMA.EWRS.Framework.ExceptionHandling;

namespace ADMA.EWRS.Data.Access
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EWRSContext _context;

        public UnitOfWork()
        {
            _context = new ADMA.EWRS.Data.Access.EWRSContext();

            //Murad :: TODO : Replace with Murad Db Logger... check formatter
#if DEBUG
            _context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
#endif

            Muradies = new MuradRepository(_context);
            Users = new UserRepository(_context);
            Projects = new ProjectsRepository(_context);
            Groups = new GroupsRepository(_context);
            Permissions = new PermissionsRepository(_context);
            Delegations = new DelegationsRepository(_context);
            OrganizationHierarchies = new OrganizationHierarchiesRepository(_context);
            Templates = new TemplateRepository(_context);
            TeamModel = new TeamModelRepository(_context);
        }

        public IMuradRepository Muradies { get; private set; }
        public IUserRepository Users { get; private set; }
        public IProjectsRepository Projects { get; private set; }
        public IGroupsRepository Groups { get; private set; }
        public IDelegationsRepository Delegations { get; private set; }
        public IPermissionsRepository Permissions { get; private set; }
        public IOrganizationHierarchiesRepository OrganizationHierarchies { get; private set; }
        public ITemplatesRepository Templates { get; private set; }
        public ITeamModelsRepository TeamModel { get; private set; }

        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                var valErrors = ValidationHelpers.TransformDbEntityValidationResult(ex.EntityValidationErrors);
                throw new ValidationException("Validation failed for one or more entities. See [ValidationErrors] property for more details", valErrors);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                //var decodedErrors = TryDecodeDbUpdateException(ex);
                //if (decodedErrors == null)
                //    throw;  //it isn't something we understand so rethrow
                //return result.SetErrors(decodedErrors);

                throw;
            }
        }

        public void Rollback()
        {
            _context
                .ChangeTracker
                .Entries()
                .ToList()
                .ForEach(x => x.Reload());
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
