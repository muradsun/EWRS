using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADMA.EWRS.Data.Models.Repositories
{
    public interface IGroupsRepository : IRepository<Group>
    {

        bool IsUserPartOfSuperAdminsGroup(int userId);
        List<ADMA.EWRS.Data.Models.Group> SearchGroups(string groupName, int Owner_UserId, int pageNumber, int recordsPerPage);

    }
}