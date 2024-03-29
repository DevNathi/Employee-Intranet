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
    public class StuffEndPoint
    {
        IApiHelper _apiHelper;
        public StuffEndPoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<EmployeeModel> GetEmployeeByUserId(int userId)
        {
            using (HttpResponseMessage httpResponse = await _apiHelper.ApiClient.GetAsync($"api/Employee/{userId}"))
            {
                try
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var employee = await httpResponse.Content.ReadAsAsync<EmployeeModel>();
                        return employee;
                    }
                }
                catch (Exception)
                {

                    throw new Exception(httpResponse.ReasonPhrase);
                }
                return new EmployeeModel();
            }
        }
        public async Task<MyManagerModel> GetMyManagerByDepartment(string department)
        {
            using (HttpResponseMessage http = await _apiHelper.ApiClient.GetAsync($"api/MyManager/{department}"))
            {
                try
                {
                    if (http.IsSuccessStatusCode)
                    {
                        var myManager = await http.Content.ReadAsAsync<MyManagerModel>();
                        return myManager;
                    }
                }
                catch (Exception)
                {

                    throw new Exception(http.ReasonPhrase);
                }
                return new MyManagerModel();
            }
        }
        public async Task<List<MyColleageas>> GetMyColleageasByDepartment(string department)
        {
            using (HttpResponseMessage http = await _apiHelper.ApiClient.GetAsync($"api/MyColeagues/{department}")) 
            {
                try
                {
                    if (http.IsSuccessStatusCode)
                    {
                        var myColleague = await http.Content.ReadAsAsync<List<MyColleageas>>();
                        return myColleague;
                    }
                }
                catch (Exception)
                {

                    throw new Exception(http.ReasonPhrase);
                }
                return new List<MyColleageas>();
            }
        }
        public async Task<EmployeeModel> UpdateEmployeeByUser(EmployeeModel employeeModel)
        {
            using (HttpResponseMessage http = await _apiHelper.ApiClient.PutAsJsonAsync($"api/Employee/", employeeModel))
            { 
                try
                {
                    if (http.IsSuccessStatusCode)
                    {
                        var employee = await http.Content.ReadAsAsync<EmployeeModel>();
                        return employee;
                    }
                }
                catch (Exception)
                {

                    throw new Exception(http.ReasonPhrase);
                }
                return new EmployeeModel();
            }
        }
    }
}