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
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string user_email { get; set; }

        
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string user_password { get; set; }

    }
    public class ProfileModel
    {
        public int Id { get; set; }
        public string profile_title { get; set; }
        public string profile_name { get; set; }
        public string profile_surname { get; set; }
        public int user { get; set; }

    }
}