﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_Intranet_UI.Models
{
    public class LeaveDisplayModel : ILeaveDisplayModel
    {
        public HomeDisplayModel user { get; set; }
        public List<LeaveModel> Myleaves { get; set; }
        public List<TypeModel> MyLeaveTypes { get; set; }

        
    }
} 