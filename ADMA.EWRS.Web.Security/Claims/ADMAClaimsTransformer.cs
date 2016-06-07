using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace ADMA.EWRS.Web.Security.Claims
{
    public class ADMAClaimsTransformer:  IClaimsTransformer
    {
        public ADMAClaimsTransformer()
        {

        }

        /// <summary>
        /// TODO :: Murad:
        /// Create ClaimsPrincipal for each request
        /// 
        /// ADD Cache fixing in future :) 
        /// </summary>
        /// <param name="incoming"></param>
        /// <returns></returns>
        public Task<ClaimsPrincipal> TransformAsync(ClaimsTransformationContext context)
        {
            var session = ((Microsoft.AspNetCore.Http.DefaultHttpContext)context.Context).Session;
            //context.Context.Session.SetInt32()
            return Task.FromResult<ClaimsPrincipal>(context.Principal );
        }

        
        //public Task<ClaimsPrincipal> TransformClaimsAsync(ClaimsPrincipal incoming)
        //{
        //    if (!incoming.Identity.IsAuthenticated)
        //    {
        //        return Task.FromResult<ClaimsPrincipal>(incoming);
        //    }

        //    // parse incoming claims - create new principal with app claims
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Role, "foo"),
        //        new Claim(ClaimTypes.Role, "bar")
        //    };

        //    var nameId = incoming.FindFirst(ClaimTypes.NameIdentifier);
        //    if (nameId != null)
        //    {
        //        claims.Add(nameId);
        //    }

        //    var thumbprint = incoming.FindFirst(ClaimTypes.Thumbprint);
        //    if (thumbprint != null)
        //    {
        //        claims.Add(thumbprint);
        //    }

        //    var id = new ClaimsIdentity("Application");
        //    id.AddClaims(claims);

        //    return Task.FromResult<ClaimsPrincipal>(new ClaimsPrincipal(id));
        //}
    }
}
