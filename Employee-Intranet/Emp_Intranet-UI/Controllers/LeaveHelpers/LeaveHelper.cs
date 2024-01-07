using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_Intranet_UI.Controllers.LeaveHelpers
{
    public class LeaveHelper
    {
        public int CalculateRemainingLeaveDays(Employee employee)
        {
            int totalLeaveDays = 20; // Assuming employees have 20 leave days per year
            int usedLeaveDays = 0;

            //foreach ()
            //{
            //    if (leaveRequest.IsApproved)
            //    {
            //        usedLeaveDays += (leaveRequest.EndDate - leaveRequest.StartDate).Days + 1;
            //    }
            //}

            return totalLeaveDays - usedLeaveDays;
        }

        public void UpdateLeaveRequestStatus(Employee employee, LeaveRequest leaveRequest, bool isApproved)
        {
           // leaveRequest.IsApproved = isApproved;
        }

        public class Employee
        {
        }
    }

    public class LeaveRequest
    {
    }
}