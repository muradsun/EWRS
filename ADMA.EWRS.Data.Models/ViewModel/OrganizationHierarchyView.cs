using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.ViewModel
{
    public class OrganizationHierarchyAutoCompleteView
    {
        public int ORGID { get; set; }
        public string ORGNAME { get; set; }
        public string BU_NAME { get; set; }
        public string DIV_NAME { get; set; }
        public string DEP_NAME { get; set; }
        public string TEAM_NAME { get; set; }
        public string SECTION_NAME { get; set; }

    }
}
