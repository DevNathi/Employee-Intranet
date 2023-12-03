namespace Emp_Intranet_UI.Models
{
    public interface ILeaveDisplayModel
    {
        EmployeeModel employee { get; set; }
        int Id { get; set; }
        LeaveModel leaves { get; set; }
        UserModel LoggedInAs { get; set; }
        ProfileModel Profile { get; set; }
    }
}