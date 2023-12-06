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
        public int leave_daystaken { get; set; }
        public int employeeID { get; set; }
        public int leavetypeid { get; set; }
        public string type_name { get; set; }
        public string type_cycle { get; set; }
        public int type_days { get; set; }
        public List<EmployeeModel> Applicant { get; set; }
    }
    public class TypeModel
    {
        public int Id { get; set; }
        public string type_name { get; set; }
        public string type_cycle { get; set; }
        public int type_days { get; set; }

    }
}