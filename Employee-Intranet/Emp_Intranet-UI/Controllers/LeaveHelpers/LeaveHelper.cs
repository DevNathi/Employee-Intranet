using Emp_Intranet_UI.Models;
using Emp_Intranet_UI.Models.DisplayModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_Intranet_UI.Controllers.LeaveHelpers
{
    public class LeaveHelper
    {

        public void UpdateLeaveRequestStatus()
        {
            // leaveRequest.IsApproved = isApproved;
        }
        //public void UpdateLeaveTypes(List<LeaveTypes> _leaveTypes, List<LeaveStatsPerEmployee> _myStatsPerLeaveType)
        //{
        //    if (_myStatsPerLeaveType != null)
        //    {
        //        foreach (var leavetype in _leaveTypes)
        //        {
        //            foreach (var leavestats in _myStatsPerLeaveType)
        //            {
        //                if (leavestats.Leave_name == leavetype.LeaveName)
        //                {
        //                    leavetype.LeaveDaysTaken = leavestats.TotalDaysTakenPerLeave;
        //                }
        //            }
        //            leavetype.LeaveDaysRemaining = leavetype.LeaveDays - leavetype.LeaveDaysTaken;
        //        }
        //    }
        //}

        public void UpdateLeaveTypes(List<LeaveTypes> _leaveTypes, List<LeaveStatsPerEmployee> _myStatsPerLeaveType, EmployeeModel employee)
        {
            if (_myStatsPerLeaveType != null)
            {
                foreach (var leavetype in _leaveTypes)
                {
                    foreach (var leavestats in _myStatsPerLeaveType)
                    {
                        if (leavestats.Leave_name == leavetype.LeaveName)
                        {
                            // Update leave days taken
                            leavetype.LeaveDaysTaken = leavestats.TotalDaysTakenPerLeave;
                        }
                    }

                    // Update remaining leave days
                    leavetype.LeaveDaysRemaining = leavetype.LeaveDays - leavetype.LeaveDaysTaken;
                }
            }
        }
    }
}