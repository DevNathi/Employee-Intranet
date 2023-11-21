﻿using Emp_Intranet_UI.API.API_Helper;
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
       private IApiHelper _apiHelper;
        public LeaveEndPoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
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
        public async Task<List<LeaveModel>> GetAllLeaves()
        {
            using (HttpResponseMessage httpResponseMessage = await _apiHelper.ApiClient.GetAsync($"api/Leaves/"))
            {
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var results = await httpResponseMessage.Content.ReadAsAsync<List<LeaveModel>>();
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