using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADMA.EWRS.Web.Core.ViewComponents
{
    //Murad :: Note
    //View component classes can be contained in any folder in the project.

    //See : https://docs.asp.net/en/latest/mvc/views/view-components.html
    //The [ViewComponent] attribute can change the name used to reference a view component. For example, we could have named the 
    //class XYZ, and applied the ViewComponent attribute:
    public class PriorityListViewComponent : ViewComponent
    {
        public PriorityListViewComponent()
        {
            
        }

        //public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        //{
        //    return View();
        //}

        //private Task<List<string> GetItemsAsync()
        //{
        //   return null;
        //}
    }
}
