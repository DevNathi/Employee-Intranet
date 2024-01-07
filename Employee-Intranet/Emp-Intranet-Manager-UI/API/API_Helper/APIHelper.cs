using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Emp_Intranet_Manager_UI.API.API_Helper
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient _apiClient;
        //Construct the Api Helper class
        public HttpClient ApiClient
        {
            get
            {
                return _apiClient;
            }
        }
        // initialize the HTTP Client 
        public APIHelper()
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