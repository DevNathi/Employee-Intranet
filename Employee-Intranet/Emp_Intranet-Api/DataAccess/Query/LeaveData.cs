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
        public List<LeaveModel> GetAllLeave()
        {


            var output = _sql.LoadData<LeaveModel, dynamic>("leave.sp_FIndLeaves", new { }, "Emp_Intranet-DB");

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
    }
}