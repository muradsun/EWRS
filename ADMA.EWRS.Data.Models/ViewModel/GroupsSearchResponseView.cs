using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.ViewModel
{
    public class GroupsSearchResponseView
    {
        public int Group_Id { get; set; }
        public string Name { get; set; }
        public List<string> Users { get; set; }
    }
}
