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
        public List<LeaveModel> GetLeavesByUser(int userId)
        {

            var output = _sql.LoadData<LeaveModel, dynamic>("leave.sp_FIndLeavebyUserId", new { Id = userId }, "Emp_Intranet-DB");

            return output;

        }
        public List<LeaveModel> GetAllLeave()
        {


            var output = _sql.LoadData<LeaveModel, dynamic>("leave.sp_FIndLeaves", new { }, "Emp_Intranet-DB");

            return output;

        }
        public List<TypeModel> GetAllLeaveTypes()
        {
            var output = _sql.LoadData<TypeModel, dynamic>("leave.sp_FindAllLeaveTypes", new { }, "Emp_Intranet-DB");
            return output;
        }
        public void AddLeaveForUser(LeaveModel NewLeave)
        {
            try
            {
                var parameters = new
                {
                    leave_name = NewLeave.LeaveName,
                    leave_startdate = NewLeave.LeaveStartDate,
                    leave_enddate = NewLeave.LeaveEndDate,
                    leave_reason = NewLeave.LeaveReason,
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
    }
}