﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_Intranet_Api.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string email { get; set; }

    }
    public class loginModel
    {
        public string user_email { get; set; }
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