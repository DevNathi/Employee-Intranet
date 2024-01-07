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
        public List<LeaveModel> leave { get; set; }
        public List<LeaveTypes> LeaveTypes { get; set; } //These will be all leave Types
        public LeaveModel MyLeaves { get; set; }
    }
    public enum LeaveTypes
    {
        Sick,
        Parental,
        Annual,
        Meternity
    }
   
}