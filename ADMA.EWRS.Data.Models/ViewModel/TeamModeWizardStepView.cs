using ADMA.EWRS.Data.Models.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.ViewModel
{
    public class TeamModeWizardStepView
    {
        public int TeamModel_Id { get; set; }
        public Nullable<int> User_Id { get; set; }
        public Nullable<int> Group_Id { get; set; }
        public int Project_Id { get; set; }
        public bool IsUpdater { get; set; }
        public uint  SequenceNo { get; set; }
    }
}
