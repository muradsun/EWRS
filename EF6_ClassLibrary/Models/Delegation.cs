using System;
using System.Collections.Generic;

namespace EF6_ClassLibrary.Models
{
    public partial class Delegation
    {
        public int Delegation_Id { get; set; }
        public int User_Id { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime ToDate { get; set; }
    }
}