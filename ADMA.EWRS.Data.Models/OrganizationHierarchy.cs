using ADMA.EWRS.Data.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    /// <summary>
    /// HR Clone View from HRMS
    /// </summary>
    public partial class OrganizationHierarchy
    {
        public string ORGNAME { get; set; }
        public int ORGID { get; set; }
        public string ORGTYPE { get; set; }
        public string BU_NAME { get; set; }
        public int BU_ID { get; set; }
        public string DIV_NAME { get; set; }
        public Nullable<int> DIV_ID { get; set; }
        public string DEP_NAME { get; set; }
        public Nullable<int> DEP_ID { get; set; }
        public string TEAM_NAME { get; set; }
        public Nullable<int> TEAM_ID { get; set; }
        public string SECTION_NAME { get; set; }
        public Nullable<int> SECTION_ID { get; set; }

        public OrganizationHierarchyAutoCompleteView TransformToAutoCompleteView()
        {
            return new OrganizationHierarchyAutoCompleteView()
            {
                BU_NAME = this.BU_NAME,
                DEP_NAME = this.DEP_NAME,
                DIV_NAME = this.DIV_NAME,
                ORGID = this.ORGID,
                ORGNAME = this.ORGNAME,
                SECTION_NAME = this.SECTION_NAME,
                TEAM_NAME = this.TEAM_NAME
            };
        }

        public string TransformToHTMLString()
        {
            return string.Format("User Organization: <b>{0}</b> / {1} <br/> BU: {2} <br/> Div: {3} <br/> Dep: {4} <br/> Team: {5}  <br/> Sec: {6}",
                this.ORGNAME, this.ORGTYPE, this.BU_NAME, this.DIV_NAME, this.DEP_NAME, this.TEAM_ID, this.SECTION_NAME);
        }
    }
}
