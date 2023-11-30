namespace Emp_Intranet_UI.Models
{
    public interface IHomeDisplayModel
    {
        EmployeeModel employee { get; set; }
        ProfileModel Profile { get; set; }
        LeaveModel leave { get; set; }
        UserModel LoggedInAs { get; set; }
    }
}