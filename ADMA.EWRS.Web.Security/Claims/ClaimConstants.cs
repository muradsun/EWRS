using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADMA.EWRS.Web.Security.Claims
{
    public class ClaimConstants
    {
        public const string Issuer = "http://www.adma-opco.com/";
        public const string MiddlewareScheme = "EWRS_Cookie";
        public const string CompanyClaimType = "http://www.adma-opco.com/identity/claims/Company";
    }
}
