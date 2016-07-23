using ADMA.EWRS.Data.Access;
using ADMA.EWRS.Data.Models;
using ADMA.EWRS.Data.Models.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.BizDomain
{
    public class OrganizationsManager : BaseManager
    {
        public OrganizationsManager(IServiceProvider provider) : base(provider)
        {

        }

        public ICollection<OrganizationHierarchyView> ResolveOrganizationHierarchy(int OrganizationID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                OrganizationHierarchy orgH = unitOfWork.OrganizationHierarchies.ResolveOrganizationHierarchy(OrganizationID);
                List<OrganizationHierarchyView> orgHView = new List<OrganizationHierarchyView>();

                //BU
                orgHView.Add(
                    new OrganizationHierarchyView()
                    {
                        OrganizationId = orgH.BU_ID,
                        OrganizationName = orgH.BU_NAME,
                        OrganizationType = "Business Unit",
                        OrganizationValue = orgH.BU_NAME,
                        IsTargetOrganization = OrganizationID == orgH.BU_ID,
                        Sort = 1
                    });


                //DIV
                orgHView.Add(
                    new OrganizationHierarchyView()
                    {
                        OrganizationId = orgH.DIV_ID.GetValueOrDefault(),
                        OrganizationName = orgH.DIV_NAME,
                        OrganizationType = "Division",
                        OrganizationValue = orgH.DIV_NAME,
                        IsTargetOrganization = OrganizationID == orgH.DIV_ID,
                        Sort = 2
                    });

                //DEP
                orgHView.Add(
                    new OrganizationHierarchyView()
                    {
                        OrganizationId = orgH.DEP_ID.GetValueOrDefault(),
                        OrganizationName = orgH.DEP_NAME,
                        OrganizationType = "Department",
                        OrganizationValue = orgH.DEP_NAME,
                        IsTargetOrganization = OrganizationID == orgH.DEP_ID,
                        Sort = 3
                    });


                //Team
                orgHView.Add(
                    new OrganizationHierarchyView()
                    {
                        OrganizationId = orgH.TEAM_ID.GetValueOrDefault(),
                        OrganizationName = orgH.TEAM_NAME,
                        OrganizationType = "Team",
                        OrganizationValue = orgH.TEAM_NAME,
                        IsTargetOrganization = OrganizationID == orgH.TEAM_ID,
                        Sort = 4
                    });

                //Sec
                orgHView.Add(
                    new OrganizationHierarchyView()
                    {
                        OrganizationId = orgH.SECTION_ID.GetValueOrDefault(),
                        OrganizationName = orgH.SECTION_NAME,
                        OrganizationType = "Section",
                        OrganizationValue = orgH.SECTION_NAME,
                        IsTargetOrganization = OrganizationID == orgH.SECTION_ID,
                        Sort = 5
                    });

                return orgHView;
            }

        }
    }
}
