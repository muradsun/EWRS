//Murad :: Info : Must ADD referance to Entity and Linq to see the extension methods
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ADMA.EWRS.Data.Models.Repositories;
using ADMA.EWRS.Data.Models;
using ADMA.EWRS.Data.Models.ViewModel;

namespace ADMA.EWRS.Data.Models
{
    public partial class ReviewWorkflow
    {
        public ReviewWorkflow()
        {
            this.ReviewWorkflowActors = new List<ReviewWorkflowActor>();
            this.ReviewWorkflowsProjects = new List<ReviewWorkflowsProject>();
        }

        public int ReviewWorkflow_Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public int Owner_UserId { get; set; }
        public User User { get; set; }
        public ICollection<ReviewWorkflowActor> ReviewWorkflowActors { get; set; }
        public ICollection<ReviewWorkflowsProject> ReviewWorkflowsProjects { get; set; }

        public ReviewWorkflowView TransformToReviewWorkflowView()
        {
            return new ReviewWorkflowView()
            {
                Name = this.Name,
                ReviewWorkflowActors = this.ReviewWorkflowActors.Select(r => r.TransformToReviewWorkflowActor()).ToList()
            };
        }
    }
}
