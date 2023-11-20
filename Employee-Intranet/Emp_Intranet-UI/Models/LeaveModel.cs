using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_Intranet_UI.Models
{
    public class LeaveModel
    {
        public int Id { get; set; }

        public DateTime leave_startdate { get; set; }
        public DateTime leave_enddate { get; set; }
        public string leave_reason { get; set; }
        public string leave_comment { get; set; }
        public int employeeID { get; set; }
        public int leavetypeid { get; set; }
    }
}