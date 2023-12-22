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
                _sql.SaveData("leave.sp_CreateNewLeaveForEmployee",
                    new
                    {
                        leave_startdate = NewLeave.leave_startdate,
                        leave_enddate = NewLeave.leave_enddate,
                        leave_reason = NewLeave.leave_reason,
                        leave_comment = NewLeave.leave_comment,
                        employeeid = NewLeave.employeeID,
                        leavetypeid = NewLeave.leavetypeid
                    },
                    "Emp_Intranet-DB");
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}