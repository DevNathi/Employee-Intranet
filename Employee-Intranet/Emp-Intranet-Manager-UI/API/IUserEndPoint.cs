using Emp_Intranet_Manager_UI.Models;
using System.Threading.Tasks;

namespace Emp_Intranet_Manager_UI.API
{
    public interface IUserEndPoint
    {
        void GetManagerProfile();
        Task<AuthenticationModel> Login(LoginModel login);
        void RegisterManager();
    }
}