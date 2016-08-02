//Murad :: Info : Must ADD referance to Entity and Linq to see the extension methods
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ADMA.EWRS.Data.Models.Repositories;
using ADMA.EWRS.Data.Models;


namespace ADMA.EWRS.Data.Access.Repositories
{
    public class PermissionsRepository : Repository<Permission, EWRSContext>, IPermissionsRepository
    {
        public PermissionsRepository(ADMA.EWRS.Data.Access.EWRSContext context)
            : base(context)
        {
        }

        public IEnumerable<Permission> GetUserPermissions(int userId)
        {
            var gList = (from gP in DbContext.GroupPermissions.Include(gp => gp.Group.GroupUsers)
                         where gP.Group.IsSystemGoup == true &&
                               gP.Group.GroupUsers.Any(gU => gU.User_Id == userId)
                         select gP.Permission);

            return gList.AsEnumerable();
        }
    }
}