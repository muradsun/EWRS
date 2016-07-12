using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.ModelView
{
    public class OrganizationHierarchyView
    {
        public int? OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationValue { get; set; }
        public string OrganizationType { get; set; }
        public bool IsTargetOrganization { get; set; }
        public uint Sort { get; set; }

    }
}
