//Murad :: Info : Must ADD referance to Entity and Linq to see the extension methods
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ADMA.EWRS.Data.Models.Repositories;
using ADMA.EWRS.Data.Models;
using ADMA.EWRS.Data.Models.ViewModel;

namespace ADMA.EWRS.Data.Access.Repositories
{
    public class UsersRepository : Repository<User, EWRSContext>, IUsersRepository
    {
        public UsersRepository(EWRSContext context)
            : base(context)
        {

        }

        public IEnumerable<User> SearchUsers(UsersSearchRequestView usersSearchRequestView, int pageIndex, int recordsPerPage, ref int recordsCount)
        {
            var q = DbContext.Users.Where(u =>
                  (usersSearchRequestView.FirstName.Trim() == "" || u.FIRST_NAME.Contains(usersSearchRequestView.FirstName)) &&
                  (usersSearchRequestView.FamilyName.Trim() == "" || u.FAMILY_NAME.Contains(usersSearchRequestView.FamilyName)) &&
                   (usersSearchRequestView.Email.Trim() == "" || u.EMAIL.Contains(usersSearchRequestView.Email)) &&
                   (usersSearchRequestView.PFNo.Trim() == "" || u.PF_NO.Contains(usersSearchRequestView.PFNo)) &&
                   (usersSearchRequestView.Title.Trim() == "" || u.POST_TITLE_LONG_DESC.Contains(usersSearchRequestView.Title)) &&
                   (usersSearchRequestView.OrganizationId == 0 || u.ORGANIZATION_ID == usersSearchRequestView.OrganizationId)
               ).OrderBy(u => u.User_Id);

            recordsCount = q.Count();
            return q.Skip((pageIndex - 1) * recordsPerPage).Take(recordsPerPage);
        }

       
    }
}
