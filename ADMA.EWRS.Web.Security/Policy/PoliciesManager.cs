using ADMA.EWRS.Security.Policy;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADMA.EWRS.Web.Security.Policy
{
    public class PoliciesManager
    {
        public static void BuildSystemPolicies(AuthorizationOptions options)
        {
            //Murad :: My workshop with Microsoft for MYassin ::  https://github.com/blowdart/AspNetAuthorizationWorkshop
            //options.AddPolicy(PolicyNames.SuperAdministrators, policy => {
            //policy => policy.RequireRole(Groups.SuperAdministratorsGroupName));
            //}

            options.AddPolicy(PolicyNames.SuperAdministrators, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole(Groups.SuperAdministratorsGroupName);
            });

            options.AddPolicy(PolicyNames.ProjectOwners, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole(/*Groups.ProjectOwners,*/
                                   Groups.SuperAdministratorsGroupName);

                //policy.RequireClaim();
                //policy.RequireAuthenticatedUser();
                //policy.RequireRole("Administrator");
                //policy.Requirements.Add(new AlbumOwnerRequirement());
            });

        }
    }
}
