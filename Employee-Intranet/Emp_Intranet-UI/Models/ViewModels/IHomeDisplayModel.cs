using System.Collections.Generic;

namespace Emp_Intranet_UI.Models.DisplayModels
{
    public interface IHomeDisplayModel
    {
        EmployeeModel employee { get; set; }
        List<LeaveModel> leave { get; set; }
        List<TypeModel> LeaveTypes { get; set; }
        UserModel LoggedInAs { get; set; }
        ProfileModel Profile { get; set; }
    }
}