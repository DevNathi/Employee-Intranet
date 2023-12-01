using System.Collections.Generic;

namespace Emp_Intranet_UI.Models
{
    public interface IHomeDisplayModel
    {
        EmployeeModel employee { get; set; }
        LeaveModel leave { get; set; }
        List<TypeModel> LeaveTypes { get; set; }
        UserModel LoggedInAs { get; set; }
        ProfileModel Profile { get; set; }
    }
}