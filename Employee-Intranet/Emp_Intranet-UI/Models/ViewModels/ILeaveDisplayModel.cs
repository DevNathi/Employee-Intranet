﻿using System.Collections.Generic;

namespace Emp_Intranet_UI.Models.DisplayModels
{
    public interface ILeaveDisplayModel
    {
        HomeDisplayModel user { get; set; }
        List<LeaveModel> Myleaves { get; set; }
        List<TypeModel> MyLeaveTypes { get; set; }
    }
}