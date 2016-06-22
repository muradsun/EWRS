using ADMA.EWRS.BizDomain;
using ADMA.EWRS.Data.Access;
using ADMA.EWRS.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ADMA.EWRS.Web.Security.Claims
{
    public class ClaimsManager
    {
        private SecurityManager _secManager;

        public ClaimsManager()
        {

        }

        public static string ExtractNameClaimFromCurrentContext(HttpContext context)
        {
            return ((ClaimsIdentity)context.User.Identity).Claims.Where(q => q.Type == ClaimTypes.Name).Select(q => q.Value).FirstOrDefault();
        }

        public User GetUserFromNameClaim(string nameClaim)
        {
            if (string.IsNullOrWhiteSpace(nameClaim))
                return null;

            //MURAD-LP\Murad
            //Murad :: TODO : Check domain is ADMA otherwise give access denied
            string pfNo = nameClaim.Split('\\')[1];

            using (var unitOfWork = new UnitOfWork())
            {
                User user = unitOfWork.Users.Find(u => u.PF_NO == pfNo && u.IsActive == true).FirstOrDefault();
                return user;
            }
        }

        public ClaimsPrincipal CreateClaimsPrincipal(User userObj)
        {
            //Get User Claims from DB
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, userObj.User_Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, userObj.EMAIL));
            claims.Add(new Claim(ClaimTypes.GivenName, userObj.EMPLOYEE_NAME));
            claims.Add(new Claim(ClaimTypes.Gender, userObj.GENDER));

            using (var unitOfWork = new UnitOfWork())
            {
                _secManager = new SecurityManager(unitOfWork);

                //Is Super Admin 
                //if (unitOfWork.Users.Groups.Find(g => g.Name == ADMA.EWRS.Web.Security.Groups.SuperAdministratorsGroupName).FirstOrDefault() != null)
                if (_secManager.IsUserPartOfSuperAdminsGroup(userObj))
                    claims.Add(new Claim(ClaimTypes.Role, Groups.SuperAdministratorsGroupName));
                else
                {
                    //Get Claims from DB 
                    List<Permission> userPerList = unitOfWork.Permissions.GetUserPermissions(userObj.User_Id).ToList();
                    if (userPerList != null && userPerList.Count > 0)
                        foreach (var permission in userPerList)
                            claims.Add(new Claim(permission.Name, permission.Permission_Id.ToString()));
                }
            }


            //Murad :: TODO : no need for issuer definitions 
            //claims.Add(new Claim(Constants.CompanyClaimType, user.Company, ClaimValueTypes.String, Constants.Issuer));
            //if (!string.IsNullOrWhiteSpace(user.Role))
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, user.Role, ClaimValueTypes.String, Constants.Issuer));
            //}

            var userIdentity = new ClaimsIdentity("EWRSClaimIdentity");
            //userIdentity.Name = string.Format("{0} ({1})", userObj.EMPLOYEE_NAME, userObj.PF_NO);
            userIdentity.AddClaims(claims);


            return new ClaimsPrincipal(userIdentity);


        }
    }
}
