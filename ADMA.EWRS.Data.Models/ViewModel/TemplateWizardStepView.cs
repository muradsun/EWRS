using ADMA.EWRS.Data.Models.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.ViewModel
{
    public class TemplateWizardStepView
    {
        public int Template_Id { get; set; }
        public int Project_Id { get; set; }
        public string Name { get; set; }
        public ICollection<SubjectWizardStepView> Subjects { get; set; }

    }
}
