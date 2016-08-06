using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models
{
    public enum ModelState
    {
        Added,
        Updated,
        Deleted,
        unknown
    }

    public abstract class BaseModel
    {
        [NotMapped]
        public ModelState EntityState { get; set; } 
    }
}
