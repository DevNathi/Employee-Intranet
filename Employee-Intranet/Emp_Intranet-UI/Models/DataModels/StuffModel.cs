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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime employee_startdate { get; set; }
        public string employee_contract { get; set; }
        public string employee_jobtitle { get; set; }
        public string employee_department { get; set; }
        public int userid { get; set; }
    }

    public class ManagementModel
    {
        public int Id { get; set; }
        public string management_level { get; set; }
        public int employeeid { get; set; }
    }

}