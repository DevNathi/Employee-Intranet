using Emp_Intranet_Api.DataAccess.InternalDataAccess;
using Emp_Intranet_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_Intranet_Api.DataAccess
{
    public class UserData : IUserData
    {
      

        public UserModel Login(loginModel login)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var user = new
            {
                sp_email = login.user_email,
                sp_username = login.user_username,
                sp_password = login.user_password
            };

            var loggedInUser = sql.LoadData<UserModel, dynamic>("user.sp_FindUser", user, "Emp_Intranet-DB").FirstOrDefault();
            try
            {
               
                if (loggedInUser!=null)
                {
                    return loggedInUser;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return loggedInUser;
        }
        public ProfileModel GetProfile(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var profile = sql.LoadData<ProfileModel, dynamic>("", new { Id }, "Emp_Intranet-DB").FirstOrDefault();
            return profile;
        }

    }
}