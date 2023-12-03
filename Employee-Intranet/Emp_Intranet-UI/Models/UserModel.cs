using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emp_Intranet_UI.Models
{
   
    public class UserModel
    {
        public int Id { get; set; }
        public string Token { get; set; }

    }
    public class loginModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string user_email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string user_password { get; set; }

    }
    public class RolesModel
    {

       
    }
    public class ProfileModel
    {
        public int Id { get; set; }
        public string profile_title { get; set; }
        public string profile_name { get; set; }
        public string profile_surname { get; set; }
        public int user { get; set; }
        public int role { get; set; }
        public string role_name { get; set; }

    }
}