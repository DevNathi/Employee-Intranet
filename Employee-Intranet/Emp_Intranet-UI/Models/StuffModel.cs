using System;
using System.Collections.Generic;
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
        public DateTime employee_startdate { get; set; }
        public string employee_contract { get; set; }
        public string employee_jobtitle { get; set; }
        public int userid { get; set; }
        public int departmentid { get; set; }
        public string department_name { get; set; }
        public string department_size { get; set; }
        public string department_location { get; set; }
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
    public class PermissionsModel
    {
        public int Id { get; set; }
        public string permission_type { get; set; }
        public string permission_name { get; set; }
    }
}