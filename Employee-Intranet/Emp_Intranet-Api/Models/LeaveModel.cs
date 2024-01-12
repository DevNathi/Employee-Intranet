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
        public string LeaveName { get; set; }
        public string LeaveReason { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
    }
    public class TypeModel
    {
        public int Id { get; set; }
        public string type_name { get; set; }
        public string type_cycle { get; set; }
        public int type_days { get; set; }

    }
}