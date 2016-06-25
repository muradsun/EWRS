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
            options.AddPolicy(PolicyNames.SuperAdministrators,
                  policy => policy.RequireRole(Groups.SuperAdministratorsGroupName));

            //options.AddPolicy(PolicyNames.CanEditProject,
            //    policy =>
            //    {
            //        policy.RequireAuthenticatedUser();
            //        policy.RequireRole("Administrator");
            //        policy.Requirements.Add(new ProjectOwnerRequirement());
            //    }
            //);
        }
    }
}
