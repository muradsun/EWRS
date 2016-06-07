using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Test_ClassLibrary_NET461
{
    public class Class_NET461 : IClaimsTransformer
    {
        public Class_NET461()
        {
           
        }

        public Task<ClaimsPrincipal> TransformAsync(ClaimsTransformationContext context)
        {
            var x = new Class_NET461();
            throw new NotImplementedException();
        }
    }
}
