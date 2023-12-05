namespace Emp_Intranet_UI.Models.DisplayModels
{
    public interface IUpdateUserInfoModel
    {
        EmployeeModel employee { get; set; }
        ProfileModel Profile { get; set; }
    }
}