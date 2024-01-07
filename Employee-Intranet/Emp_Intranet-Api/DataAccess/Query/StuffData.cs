using Emp_Intranet_Api.DataAccess.InternalDataAccess;
using Emp_Intranet_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_Intranet_Api.DataAccess.Query
{
    public class StuffData
    {
        SqlDataAccess _sql = new SqlDataAccess();
        public EmployeeModel GetEmployeeByUserId(int userID)
        {

            var employee = _sql.LoadData<EmployeeModel, dynamic>("stuff.sp_FIndEmployeeByUserId", new { userId = userID }, "Emp_Intranet-DB").FirstOrDefault();
            return employee;
        }
        public MyManagerModel GetMyManangerByDepartment(string manager_Department)
        {
            try
            {
                var myMananger = _sql.LoadData<MyManagerModel, dynamic>("stuff.sp_FindMyManangerByDepartment", new { department = manager_Department }, "Emp_Intranet-DB").FirstOrDefault();
                return myMananger;
            }
            catch (Exception)
            {

                throw new Exception("Sorry we did not find your manager");
            }
        }
        public void UpdateEmployee(EmployeeModel employee)
        {
            SqlDataAccess sql = new SqlDataAccess();

            if (employee is null) return;
            try
            {
                sql.SaveData("stuff.sp_UpdateEmployee",
                    new
                    {
                        userID = employee.userid,
                        newJobtitle = employee.employee_jobtitle,
                        newContract = employee.employee_contract,
                        newStartdate =  employee.employee_startdate
                    },
                   "Emp_Intranet-DB");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
    }
}