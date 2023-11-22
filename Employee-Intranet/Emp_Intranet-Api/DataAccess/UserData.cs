using Emp_Intranet_Api.DataAccess.InternalDataAccess;
using Emp_Intranet_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_Intranet_Api.DataAccess
{
    public class UserData
    {
        public UserModel Login(loginModel login )
        {
            SqlDataAccess sql = new SqlDataAccess();

            var loggedInUser = sql.LoadData<UserModel, dynamic>("[STORED PROCEDURE]", new {login}, "Emp_Intranet-DB").FirstOrDefault();

            return loggedInUser;
        }
        public ProfileModel GetProfile(UserModel user)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var profile = sql.LoadData<ProfileModel, dynamic>("", new { user }, "Emp_Intranet-DB").FirstOrDefault();
            return profile;
        }
    }
}