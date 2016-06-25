using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.Security
{
    public interface IClaimsSecurityManager
    {
        LoggedInUser CurrentUser { get; }
        string Version { get; }

    }
}
