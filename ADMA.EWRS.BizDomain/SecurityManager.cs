using ADMA.EWRS.Data.Access;
using ADMA.EWRS.Data.Models;
using ADMA.EWRS.Data.Models.Data;
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



    }
}
