using System.Net.Http;

namespace Emp_Intranet_UI.API.API_Helper
{
    public interface IApiHelper
    {
        HttpClient ApiClient { get; }
    }
}