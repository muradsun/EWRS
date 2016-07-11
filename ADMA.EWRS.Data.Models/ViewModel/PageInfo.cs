using ADMA.EWRS.Data.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.ViewModel
{
    public class PageInfo
    {
        public PageInfo(LoggedInUser currentUser)
        {
            CurrentUser = currentUser;
            Title = string.Empty;
            Description = string.Empty;
            Breadcrumbs = new List<ViewModel.Breadcrumb>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Breadcrumb> Breadcrumbs { get; set; }
        public LoggedInUser CurrentUser { get;  }
    }
}
