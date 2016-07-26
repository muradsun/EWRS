﻿using ADMA.EWRS.Data.Access;
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

        public List<User> SearchUsers(UsersSearchRequestView usersSearchRequestView)
        {
            int Page = 1;
            int RecordsPerPage = 10;

            using (var unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Users.Find(u =>
                   (usersSearchRequestView.FirstName.Trim() == "" || u.FIRST_NAME.Contains(usersSearchRequestView.FirstName)) &&
                   (usersSearchRequestView.FamilyName.Trim() == "" || u.FAMILY_NAME.Contains(usersSearchRequestView.FamilyName)) &&
                    (usersSearchRequestView.Email.Trim() == "" || u.EMAIL.Contains(usersSearchRequestView.Email)) &&
                    (usersSearchRequestView.PFNo.Trim() == "" || u.PF_NO.Contains(usersSearchRequestView.PFNo)) &&
                    (usersSearchRequestView.Title.Trim() == "" || u.POST_TITLE_LONG_DESC.Contains(usersSearchRequestView.Title)) &&
                    (usersSearchRequestView.OrganizationId == 0 || u.ORGANIZATION_ID == usersSearchRequestView.OrganizationId)
                ).Skip((Page - 1) * RecordsPerPage).Take(RecordsPerPage).ToList();
            }
        }

        public List<ADMA.EWRS.Data.Models.Group> SearchGroups(string groupName, int owner_UserId)
        {
            int page = 1;
            int recordsPerPage = 10;
            using (var unitOfWork = new UnitOfWork())
                return unitOfWork.Groups.SearchGroups(groupName, owner_UserId, page, recordsPerPage);
        }

    }
}
