using Emp_Intranet_Manager_UI.API.API_Helper;
using Emp_Intranet_Manager_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Emp_Intranet_Manager_UI.API
{
    public class UserEndPoint : IUserEndPoint
    {
        IAPIHelper _api;

        public UserEndPoint(IAPIHelper api)
        {
            _api = api;
        }

        //Log in for managers

        public async Task<AuthenticationModel> Login(LoginModel login)
        {
            var p = new
            {
                user_email = login.user_email,
                user_password = login.user_password
            };

            using (HttpResponseMessage httpResponseMessage = await _api.ApiClient.PostAsJsonAsync($"api/Login", p))
            {
                try
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var results = await httpResponseMessage.Content.ReadAsAsync<AuthenticationModel>();
                        return results;
                    }
                }
                catch (Exception)
                {

                    throw new Exception(httpResponseMessage.ReasonPhrase);
                }
                return new AuthenticationModel();
            }

        }
        public void RegisterManager()
        {

        }
        public void GetManagerProfile()
        {

        }
    }
}