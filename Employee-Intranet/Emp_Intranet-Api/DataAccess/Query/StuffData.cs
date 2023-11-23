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
        public  List<EmployeeModel> GetEmployeeByUserId(int userID)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var employee =  sql.LoadData<EmployeeModel, dynamic>("stuff.sp_FIndEmployeeByUserId", new { userId = userID }, "Emp_Intranet-DB");
            return employee;
        }
        public List<DepartmentModel> GetDepartmentById(int depID)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var department = sql.LoadData<DepartmentModel, dynamic>("stuff.sp_Find DepartmentById", new { Id = depID }, "Emp_Intranet-DB");
            return department;
        }
        public List<PermissionsModel> GetPermissionsById(int pemID)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var permissions = sql.LoadData<PermissionsModel, dynamic>("stuff.sp_FindPermissionsByUserId", new { userId = pemID }, "Emp_Intranet-DB");
            return permissions;
        }
    }
}