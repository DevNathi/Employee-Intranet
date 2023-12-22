using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emp_Intranet_UI.Models
{
    public class LeaveModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime leave_startdate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime leave_enddate { get; set; }

        [Required(ErrorMessage = "Reason is required.")]
        [StringLength(100, ErrorMessage = "The reason must be at least {2} characters long.", MinimumLength = 5)]
        public string leave_reason { get; set; }

        public string leave_comment { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Days taken must be greater than 0.")]
        public int leave_daystaken { get; set; }

        [Required(ErrorMessage = "Employee ID is required.")]
        public int employeeID { get; set; }

        [Required(ErrorMessage = "Leave type ID is required.")]
        public int leavetypeid { get; set; }

        [Required(ErrorMessage = "Leave type name is required.")]
        public string type_name { get; set; }

        [Required(ErrorMessage = "Type cycle is required.")]
        public string type_cycle { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Type days must be greater than 0.")]
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