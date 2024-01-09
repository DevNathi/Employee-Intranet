using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emp_Intranet_Api.Models
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
    public class MyManagerModel
    {
        public int Id { get; set; }
        public string manager_jobtitle { get; set; }
        public string manager_department { get; set; }
        public string manager_contract { get; set; }
        public DateTime manager_startdate { get; set; }
        public int userid { get; set; }
        public string profile_title { get; set; }
        public string profile_name { get; set; }
        public string profile_surname { get; set; }
        public int user { get; set; }
    }
    public  class MyColleageas
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime employee_startdate { get; set; }
        public string employee_contract { get; set; }
        public string employee_jobtitle { get; set; }
        public string employee_department { get; set; }
        public int userid { get; set; }
        public string profile_title { get; set; }
        public string profile_name { get; set; }
        public string profile_surname { get; set; }
        public int user { get; set; }

    }
}