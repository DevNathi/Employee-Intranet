using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emp_Intranet_Api.Models
{
    public class LeaveModel
    {
        public int Id { get; set; }
        public string Leave_Name { get; set; }
        public string Leave_Reason { get; set; }
        public DateTime Leave_StartDate { get; set; }
        public DateTime Leave_EndDate { get; set; }
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }

    }
    public class MyLeaveRecords
    {
        public int Id { get; set; }
        public string Leave_Name { get; set; }
        public string Leave_Reason { get; set; }
        public DateTime Leave_StartDate { get; set; }
        public DateTime Leave_EndDate { get; set; }
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public string Approval_status { get; set; }
        public int LeaveId { get; set; }
    }
    public class LeaveStatsPerEmployee
    {
        public string Leave_name { get; set; }
        public int TotalDaysTakenPerLeave { get; set; }

    }
}