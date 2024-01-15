using System.Collections.Generic;

namespace Emp_Intranet_UI.Models.DisplayModels
{
    public interface IHomeDisplayModel
    {
        EmployeeModel employee { get; set; }
        List<MyLeaveRecords> MyLeaveRecord { get; set; }
        List<LeaveTypes> LeaveTypes { get; set; }
        UserModel LoggedInAs { get; set; }
        List<MyColleageas> MyColleagues { get; set; }
        LeaveModel MyLeaves { get; set; }
        ProfileModel Profile { get; set; }
        MyManagerModel MyManager { get; set; }
        List<LeaveStatsPerEmployee> MyLeaveStatsPerLeave { get; set; }
    }
}