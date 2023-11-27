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
        public LeaveModel GetLeaveById(int leaveID)
        {

            var output = _sql.LoadData<LeaveModel, dynamic>("leave.sp_FIndLeavebyId", new { Id = leaveID }, "Emp_Intranet-DB").FirstOrDefault();

            return output;

        }
        public List<LeaveModel> GetAllLeave()
        {


            var output = _sql.LoadData<LeaveModel, dynamic>("leave.sp_FIndLeaves", new { }, "Emp_Intranet-DB");

            return output;

        }
    }
}