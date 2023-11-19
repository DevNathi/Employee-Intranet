using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_Intranet_Api.Models
{
    public class LeaveModel
    {
        int Id;
        
        DateTime leave_startdate;
        DateTime leave_enddate;
        string leave_reason;
        string leave_comment;
        int employeeID;
        int leavetypeid;
    }
}