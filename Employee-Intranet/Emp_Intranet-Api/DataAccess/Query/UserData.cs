﻿using Emp_Intranet_Api.DataAccess.InternalDataAccess;
using Emp_Intranet_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_Intranet_Api.DataAccess
{
    public class UserData : IUserData
    {
      
        /// <summary>
        /// This method passes in a log in model that will be used as parameters for the Stored Procedure
        /// </summary>
        /// <param name="login"></param>
        /// <returns>a User model</returns>
        public UserModel Login(loginModel login)
        {
            
            SqlDataAccess sql = new SqlDataAccess(); // !!!! - I was lazy to configure dependency injection so that i dont have to instantiate a new instance of the SQL every time i need it.

            var user = new
            {
                sp_email = login.user_email,
                sp_username = login.user_username,
                sp_password = login.user_password
            };
            // This is where we construct the SQL query that we will be passing to the SQL Client.
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
            return loggedInUser?? null;
        }
        /// <summary>
        /// Here we are passing in an ID to get a Profile 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProfileModel GetProfile(int userId)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var profile = sql.LoadData<ProfileModel, dynamic>("user.sp_FindProfileByID", new { Id = userId }, "Emp_Intranet-DB").FirstOrDefault();
            return profile;
        }

    }
}