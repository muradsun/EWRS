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
    public class GroupsRepository : Repository<Group, EWRSContext>, IGroupsRepository
    {
        public GroupsRepository(EWRSContext context)
            : base(context)
        {

        }

        public bool IsUserPartOfSuperAdminsGroup(int userId)
        {
            // _unitOfWork.Groups.Find( c => c.Name == SecurityConstants.SuperAdminsGroupName && c.GroupUsers.Any( gU => gU.User_Id == userObj.User_Id))
            return DbContext.Groups.Include("GroupUsers").Any(
                                                               g => g.Name == SecurityConstants.SuperAdminsGroupName &&
                                                               g.GroupUsers.Any(gU => gU.User_Id == userId && gU.Group_Id == g.Group_Id)
                                                          );
        }
    }
}