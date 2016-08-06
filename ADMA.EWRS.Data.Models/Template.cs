using ADMA.EWRS.Data.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADMA.EWRS.Data.Models
{
    public partial class Template : BaseModel
    {
        public Template()
        {
            this.Subjects = new List<Subject>();
        }

        public int Template_Id { get; set; }
        public string Name { get; set; }
        public int Project_Id { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public Project Project { get; set; }
        public List<Subject> Subjects { get; set; }

        public TemplateWizardStepView TransformToTemplateWizardStepView()
        {
            return new TemplateWizardStepView()
            {
                Name = this.Name,
                Project_Id = this.Project_Id,
                Subjects = this.Subjects.Select(s => s.TransformToSubjectWizardStepView()).ToList(),
                Template_Id = this.Template_Id
            };
        }

    }
}
