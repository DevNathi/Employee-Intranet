using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Emp_Intranet_UI.API.API_Helper
{
    public class ApiHelper
    {
        private HttpClient _apiClient;

        public HttpClient ApiClient
        {
            get
            {
                return _apiClient;
            }
        }
        //Construct the Api Helper class and initialize the HTTP Client 
        public ApiHelper()
        {
            InitializeCLient();
        }


        //We initialize the HTTP client and format the clients headings to pass the data as a json objet
        private void InitializeCLient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));
        }
    }
}