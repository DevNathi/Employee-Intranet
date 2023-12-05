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
        public List<TypeModel> LeaveTypes { get; set; }
    }
}