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
        [Display(Name = "Leave Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime leave_startdate { get; set; }
        [Display(Name = "Leave End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime leave_enddate { get; set; }
        public string leave_reason { get; set; }
        public string leave_comment { get; set; }
        public int employeeID { get; set; }
        public int leave_daystaken { get; set; }
        public int leavetypeid { get; set; }
        public string type_name { get; set; }
        public string type_cycle { get; set; }
        public int type_days { get; set; }
    }
    public class TypeModel
    {
        public int Id { get; set; }
        public string type_name { get; set; }
        public string type_cycle { get; set; }
        public int type_days { get; set; }

    }
}