using ADMA.EWRS.Data.Access;
using ADMA.EWRS.Data.Models;
using ADMA.EWRS.Data.Models.Data;
using ADMA.EWRS.Data.Models.ViewModel;
using ADMA.EWRS.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.BizDomain
{
    public class SecurityManager
    {
        private UnitOfWork _unitOfWork;

        public SecurityManager()
        {
        }

        public SecurityManager(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool IsUserPartOfSuperAdminsGroup(User userObj)
        {
            if (_unitOfWork != null)
                return _unitOfWork.Groups.IsUserPartOfSuperAdminsGroup(userObj.User_Id);
            else
                using (_unitOfWork)
                    return _unitOfWork.Groups.IsUserPartOfSuperAdminsGroup(userObj.User_Id);
        }

        public List<Delegation> GetUserDelegation(int userId)
        {
            return _unitOfWork.Delegations.GetUserDelegation(userId).ToList();
        }

        public List<User> SearchUsers(UsersSearchRequestView usersSearchRequestView, int pageIndex, ref int recordsCount)
        {
            using (var unitOfWork = new UnitOfWork())
                return unitOfWork.Users.SearchUsers(usersSearchRequestView, pageIndex, Configurations.Instance.RecordsPerPage, ref recordsCount).ToList();
        }

        public List<ADMA.EWRS.Data.Models.Group> SearchGroups(string groupName, int owner_UserId, int pageIndex, ref int recordsCount)
        {
            using (var unitOfWork = new UnitOfWork())
                return unitOfWork.Groups.SearchGroups(groupName, owner_UserId, pageIndex, Configurations.Instance.RecordsPerPage, ref recordsCount);
        }

    }
}
