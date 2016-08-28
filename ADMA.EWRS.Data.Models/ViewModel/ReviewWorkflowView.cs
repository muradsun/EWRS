using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.ViewModel
{
    public class ReviewWorkflowView
    {
        public string Name { get; set; }
        public virtual ICollection<ReviewWorkflowActorView> ReviewWorkflowActors { get; set; }
    }

    public class ReviewWorkflowActorView {
        public byte SequenceNo { get; set; }
        public Nullable<int> Group_Id { get; set; }
        public Nullable<int> User_Id { get; set; }
        public string Group_Name { get; set; }
        public string User_Name { get; set; }
    }

}
