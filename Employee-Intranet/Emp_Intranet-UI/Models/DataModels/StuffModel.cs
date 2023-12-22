using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emp_Intranet_UI.Models
{
    public class StuffModel
    {

    }
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime employee_startdate { get; set; }

        [Required(ErrorMessage = "Contract is required.")]
        public string employee_contract { get; set; }

        [Required(ErrorMessage = "Job title is required.")]
        public string employee_jobtitle { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int userid { get; set; }

        [Required(ErrorMessage = "Department ID is required.")]
        public int departmentid { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        public string department_name { get; set; }

        [Required(ErrorMessage = "Department size is required.")]
        public string department_size { get; set; }

        [Required(ErrorMessage = "Department location is required.")]
        public string department_location { get; set; }

        [Required(ErrorMessage = "Department manager is required.")]
        public string department_manager { get; set; }
    }

    public class DepartmentModel
    {
        public int Id { get; set; }
        public string department_name { get; set; }
        public string department_size { get; set; }
        public string department_location { get; set; }
    }
    public class ManagementModel
    {
        public int Id { get; set; }
        public string management_level { get; set; }
        public int employeeid { get; set; }
    }

}