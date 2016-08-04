using ADMA.EWRS.Data.Models.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.ViewModel
{
    public class JSONResultView
    {
        public object Data { get; set; }
        public bool Success { get; set; }
        public IEnumerable<ValidationError> BusinessErrors { get; set; }
    }
}
