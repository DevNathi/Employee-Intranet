using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emp_Intranet_UI.Models.DisplayModels
{
    public class UpdateUserInfoModel : IUpdateUserInfoModel
    {
        public ProfileModel Profile { get; set; }
        public EmployeeModel employee { get; set; }
    }
}