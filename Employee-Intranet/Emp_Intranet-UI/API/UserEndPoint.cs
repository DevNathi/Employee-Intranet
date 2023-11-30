using Emp_Intranet_UI.API.API_Helper;
using Emp_Intranet_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Emp_Intranet_UI.API
{

    public class UserEndPoint
    {
        IApiHelper _apiHelper;
        public UserEndPoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        /// <summary>
        /// We pass in a login Model and getting back a profile model 
        /// </summary>
        /// <param name="login"></param>
        /// <returns>User Model/ Logged In user</returns>
        public async Task<UserModel> Login(loginModel login)
        {
            var p = new
            {
                user_email = login.user_email,
                user_password = login.user_password
            };

            using (HttpResponseMessage httpResponseMessage = await _apiHelper.ApiClient.PostAsJsonAsync($"api/Login",p))
            {
                try
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var results = await httpResponseMessage.Content.ReadAsAsync<UserModel>();
                        return results;
                    }
                }
                catch (Exception)
                {

                    throw new Exception(httpResponseMessage.ReasonPhrase);
                }
                return new UserModel();
            }

        }
        public async Task<ProfileModel> GetProfileByUser(int userId)
        {
            using (HttpResponseMessage httpResponse = await _apiHelper.ApiClient.GetAsync($"api/Profile/{userId}"))
            {
                try
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var profile = await httpResponse.Content.ReadAsAsync<ProfileModel>();
                        return profile;
                    }
                }
                catch (Exception)
                {

                    throw new Exception(httpResponse.ReasonPhrase);
                }
                return new ProfileModel();
            }
        }
    }
}