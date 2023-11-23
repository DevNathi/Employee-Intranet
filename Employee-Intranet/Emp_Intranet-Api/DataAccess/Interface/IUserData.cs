using Emp_Intranet_Api.Models;

namespace Emp_Intranet_Api.DataAccess
{
    public interface IUserData
    {
        ProfileModel GetProfile(int Id);
        UserModel Login(loginModel login);
    }
}