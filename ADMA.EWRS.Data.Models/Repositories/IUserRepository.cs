using ADMA.EWRS.Data.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User>  SearchUsers(UsersSearchRequestView usersSearchRequestView, int pageIndex, int recordsPerPage, ref int recordsCount);
    }
}
