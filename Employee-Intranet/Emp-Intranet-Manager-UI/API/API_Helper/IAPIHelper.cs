using System.Net.Http;

namespace Emp_Intranet_Manager_UI.API.API_Helper
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
    }
}