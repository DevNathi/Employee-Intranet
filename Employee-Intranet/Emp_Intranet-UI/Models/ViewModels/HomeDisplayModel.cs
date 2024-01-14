using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_Intranet_UI.Models.DisplayModels
{
    public class HomeDisplayModel : IHomeDisplayModel
    {
        public UserModel LoggedInAs { get; set; }
        public ProfileModel Profile { get; set; }
        public EmployeeModel employee { get; set; }
        public List<MyLeaveRecords> MyLeaveRecord { get; set; }
        public List<LeaveTypes> LeaveTypes { get; set; } //These will be all leave Types
        public LeaveModel MyLeaves { get; set; } = new LeaveModel();
        public List<MyColleageas> MyColleagues { get; set; }
        public MyManagerModel MyManager { get; set; }
    }
    public class LeaveTypes
    {
        public string LeaveName { get; set; }
        public int LeaveDays { get; set; }
    }
   
}