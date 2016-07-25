﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.ViewModel
{
    public class UsersSearchResponseView
    {
        public int User_Id { get; set; }
        public string PFNo { get; set; }
        public string EmployeeName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationHierarchyText { get; set; }
    }
}
