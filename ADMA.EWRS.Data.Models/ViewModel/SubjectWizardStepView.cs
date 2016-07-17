using ADMA.EWRS.Data.Models.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.ViewModel
{
    public class SubjectWizardStepView
    {
        public int Template_Id { get; set; }
        public int Subject_Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public bool IsMandatory { get; set; }
        public int SequenceNo { get; set; }

    }
}
