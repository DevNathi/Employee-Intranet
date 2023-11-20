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
    public class LeaveEndPoint
    {
       private ApiHelper _apiHelper;
        public LeaveEndPoint(ApiHelper apiHelper)
        {
            apiHelper = _apiHelper;
        }

        public async Task<LeaveModel> GetLeaveBYId(int Id)
        {
            using(HttpResponseMessage httpResponseMessage = await _apiHelper.ApiClient.GetAsync($"api/Leave/?Id={Id}"))
            {
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var results = await httpResponseMessage.Content.ReadAsAsync<LeaveModel>();
                    return results;
                }
                else
                {
                    throw new Exception(httpResponseMessage.ReasonPhrase);
                }
            }
            
        }
    }
}