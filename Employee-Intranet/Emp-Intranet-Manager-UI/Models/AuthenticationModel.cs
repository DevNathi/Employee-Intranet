using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emp_Intranet_Manager_UI.Models
{
    public class AuthenticationModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
    public class LoginModel
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
}