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
        public List<MyColleageas> GetMycolleague(string department)
        {
            try
            {
                var myColleagues = _sql.LoadData<MyColleageas, dynamic>("stuff.sp_FindMyColleageas", new { colleagues = department}, "Emp_Intranet-DB");
                return myColleagues;
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
                        e_userid = employee.userid,
                        e_jobtitle = employee.employee_jobtitle,
                        e_contract = employee.employee_contract,
                        e_startdate =  employee.employee_startdate,
                        e_department = employee.employee_department
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