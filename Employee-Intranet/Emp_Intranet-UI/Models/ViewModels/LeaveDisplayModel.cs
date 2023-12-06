using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_Intranet_UI.Models.DisplayModels
{
    public class LeaveDisplayModel 
    {
        public HomeDisplayModel user { get; set; }
        public List<LeaveModel> Myleaves { get; set; }
        public List<TypeModel> MyLeaveTypes { get; set; }

        
    }
} 