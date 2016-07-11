using ADMA.EWRS.BizDomain;
using ADMA.EWRS.Data.Access;
using ADMA.EWRS.Data.Models;
using ADMA.EWRS.Data.Models.Security;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ADMA.EWRS.Web.Security.Claims
{
    public class ClaimsSecurityManager : IClaimsSecurityManager
    {
        //private readonly IHttpContextAccessor _contextAccessor;
        private LoggedInUser _user;

        //public ClaimsSecurityManager(ClaimsPrincipal user)
        //{
        //    SetClaimsSecurityManager(user);
        //}

        public ClaimsSecurityManager(IHttpContextAccessor contextAccessor)
        {
            //_contextAccessor = contextAccessor;
            SetClaimsSecurityManager(contextAccessor.HttpContext.User);
        }


        private void SetClaimsSecurityManager(ClaimsPrincipal user)
        {
            ClaimsIdentity identity = ((ClaimsIdentity)user.Identities.FirstOrDefault(i => i.AuthenticationType == ClaimConstants.AuthenticationType));

            string email = identity.Claims.Where(q => q.Type == ClaimTypes.Email).Select(q => q.Value).FirstOrDefault();
            string givenName = identity.Claims.Where(q => q.Type == ClaimTypes.GivenName).Select(q => q.Value).FirstOrDefault();
            string gender = identity.Claims.Where(q => q.Type == ClaimTypes.Gender).Select(q => q.Value).FirstOrDefault();

            List<string> permissionSet = identity.Claims.Where(q => q.Type == "Permission").Select(q => q.Value).ToList();
            List<string> groupSet = identity.Claims.Where(q => q.Type == ClaimTypes.Role).Select(q => q.Value).ToList();
            List<int> delegationSet = identity.Claims.Where(q => q.Type == ClaimTypes.Actor).Select(q => int.Parse(q.Value)).ToList<int>();

            _user = new LoggedInUser(int.Parse(identity.Name), email, givenName, gender, permissionSet, groupSet, delegationSet);
        }

        public LoggedInUser CurrentUser
        {
            get
            {
                return _user;
            }
        }

        public string Version
        {
            get
            {
                return "1.0";
            }
        }
    }
}
