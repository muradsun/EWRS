using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.ViewModel
{
    public class UsersSearchRequestView
    {
        public string PFNo { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public int OrganizationId { get; set; }
        public int PageIndex { get; set; }


    }
}
