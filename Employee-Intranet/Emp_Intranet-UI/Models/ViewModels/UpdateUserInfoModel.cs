using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emp_Intranet_UI.Models.DisplayModels
{
    public class UpdateUserInfoModel : IUpdateUserInfoModel
    {
        public ProfileModel Profile { get; set; }
        public EmployeeModel employee { get; set; }

        //public int profile_Id { get; set; }
        //[Required(ErrorMessage = "Title is required.")]
        //public string profile_title { get; set; }
        //[Required(ErrorMessage = "Name is required.")]
        //public string profile_name { get; set; }
        //[Required(ErrorMessage = "Surname is required.")]
        //public string profile_surname { get; set; }

        //public int user { get; set; }
        //public int role { get; set; }
        //[Required(ErrorMessage = "Role is required.")]
        //public string role_name { get; set; }

        //public int employee_Id { get; set; }
        //[Required(ErrorMessage = "Date is required.")]
        //[DataType(DataType.Date, ErrorMessage ="Date is not valid")]
        //public DateTime employee_startdate { get; set; }
        //[Required(ErrorMessage = "Contract is required.")]
        //public string employee_contract { get; set; }
        //[Required(ErrorMessage = "jb title is required.")]
        //public string employee_jobtitle { get; set; }
        //public int userid { get; set; }
        //public int department_id { get; set; }
        //[Required(ErrorMessage = "Department is required.")]
        //public string department_name { get; set; }
        //public string department_size { get; set; }
        //public string department_location { get; set; }
    }
}