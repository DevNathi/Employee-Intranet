using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_Intranet_UI.Models
{
    public class LeaveDisplayModel : ILeaveDisplayModel
    {
        public int Id { get; set; }
        public UserModel LoggedInAs { get; set; }
        public ProfileModel Profile { get; set; }
        public EmployeeModel employee { get; set; }
        public LeaveModel leaves { get; set; }


    }
}