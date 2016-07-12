using ADMA.EWRS.Data.Models.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.ViewModel
{
    public class ProjectInfoWizardStepView
    {
        public int Project_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ORGANIZATION_ID { get; set; }

        public List<OrganizationHierarchyView> OrganizationHierarchyTree { get; set; }

    }
}
