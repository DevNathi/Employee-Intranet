using Emp_Intranet_Api.DataAccess.InternalDataAccess;
using Emp_Intranet_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_Intranet_Api.DataAccess
{
    public class LeaveData 
    {

        SqlDataAccess _sql = new SqlDataAccess();
        public List<MyLeaveRecords> GetLeavesByEmployeeId(int employeeId)
        {

            var output = _sql.LoadData<MyLeaveRecords, dynamic>("leave.sp_FindAllLeavesByEmployeeId", new { employeeId = employeeId }, "Emp_Intranet-DB");

            return output;

        }
        public LeaveModel GetLeaveById(int leaveId)
        {

            var output = _sql.LoadData<LeaveModel, dynamic>("leave.sp_FindLeaveById", new { leaveId = leaveId }, "Emp_Intranet-DB").FirstOrDefault();

            return output;

        }
        public void DeleteLeaveById(int leaveId)
        {
            _sql.SaveData<dynamic>("leave.sp_DeleteLeaveById", new { leaveId = leaveId }, "Emp_Intranet-DB");
        }
        public List<LeaveModel> GetAllLeave()
        {


            var output = _sql.LoadData<LeaveModel, dynamic>("leave.sp_FIndLeaves", new { }, "Emp_Intranet-DB");

            return output;

        }
        public List<LeaveStatsPerEmployee> GetLeaveStatsForEmployeePerLeave(int employeeId)
        {


            var output = _sql.LoadData<LeaveStatsPerEmployee, dynamic>("leave.sp_CountOfLeaveDaysPerLeave", new { employeeId = employeeId }, "Emp_Intranet-DB");

            return output;

        }
        public void AddLeaveForUser(LeaveModel NewLeave)
        {
            try
            {
                var parameters = new
                {
                    leave_name = NewLeave.Leave_Name,
                    leave_startdate = NewLeave.Leave_StartDate,
                    leave_enddate = NewLeave.Leave_EndDate,
                    leave_reason = NewLeave.Leave_Reason,
                    employeeid = NewLeave.EmployeeId,
                    managerid = NewLeave.ManagerId
                };

                int rowsAffected = _sql.SaveData("leave.sp_CreateNewLeaveForEmployee", parameters, "Emp_Intranet-DB");

                if (rowsAffected > 0)
                {
                    // Success
                    Console.WriteLine("Leave created successfully");
                }
                else
                {
                    // Failure
                    Console.WriteLine("Failed to create leave");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateLeaveForUser(LeaveModel Leave)
        {
            try
            {
                var parameters = new
                {
                    Id = Leave.Id,
                    leave_name = Leave.Leave_Name,
                    leave_startdate =Leave .Leave_StartDate,
                    leave_enddate = Leave.Leave_EndDate,
                    leave_reason = Leave.Leave_Reason,
                    employeeid = Leave.EmployeeId,
                    managerid = Leave.ManagerId
                };

                int rowsAffected = _sql.SaveData("leave.sp_UpdateLeaveForEmployee", parameters, "Emp_Intranet-DB");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}