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
        public void UpdateLeaveTypes(List<LeaveTypes> _leaveTypes, List<LeaveStatsPerEmployee> _myStatsPerLeaveType)
        {
            if (_myStatsPerLeaveType != null)
            {
                foreach (var leavetype in _leaveTypes)
                {
                    foreach (var leavestats in _myStatsPerLeaveType)
                    {
                        if (leavestats.Leave_name == leavetype.LeaveName)
                        {
                            leavetype.LeaveDaysTaken = leavestats.TotalDaysTakenPerLeave;
                        }
                    }
                    leavetype.LeaveDaysRemaining = leavetype.LeaveDays - leavetype.LeaveDaysTaken;
                }
            }
        }
        public static bool CanApplyLeave(EmployeeModel employee, LeaveTypes leaveType, int daysRequested)
        {
            // Check if the employee and leave type are valid
            if (employee == null || leaveType == null)
            {
                return false;
            }

            // Get the remaining leave days for the specified leave type
            int remainingLeaveDays = GetRemainingLeaveDays(employee, leaveType);

            // Check if there are enough leave days available
            return remainingLeaveDays >= daysRequested;
        }

        public static void ApplyLeave(EmployeeModel employee, LeaveTypes leaveType, int daysRequested)
        {
            // Check if leave can be applied
            if (CanApplyLeave(employee, leaveType, daysRequested))
            {
                // Deduct leave days
                DeductLeaveDays(employee, leaveType, daysRequested);

                // Additional logic for applying leave, e.g., updating database, sending notifications, etc.
            }
            else
            {
                // Handle case where leave cannot be applied (not enough leave days)
                // You may throw an exception, return an error message, or take other appropriate actions.
                // For example:
                // throw new InvalidOperationException("Not enough leave days available.");
                // return "Not enough leave days available.";
            }
        }

        private static int GetRemainingLeaveDays(EmployeeModel employee, LeaveTypes leaveType)
        {
            // Implement logic to get remaining leave days from the database or another data source
            // Example: return remaining leave days for the specified employee and leave type

            // For demonstration purposes, assuming you have properties like LeaveBalance in your models:
            return employee?.LeaveBalances?.FirstOrDefault(lb => lb.LeaveTypeId == leaveType.Id)?.Balance ?? 0;
        }

        private static void DeductLeaveDays(EmployeeModel employee, LeaveTypes leaveType, int days)
        {
            // Implement logic to deduct leave days from the database or another data source
            // Example: Deduct the specified number of days from the employee's leave balance

            // For demonstration purposes, assuming you have properties like LeaveBalance in your models:
            var leaveBalance = employee?.LeaveBalances?.FirstOrDefault(lb => lb.LeaveTypeId == leaveType.Id);
            if (leaveBalance != null)
            {
                leaveBalance.Balance -= days;
                // Save changes to the database or update the data source accordingly
            }
        }
    }



}
}