using System;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Emp_Intranet_Api.DataAccess.InternalDataAccess
{
    /// <summary>
    /// In this class handles the SQL connection string using the SQL client
    /// We us Dapper to Map models as we will be passing generics as our parameters 
    /// </summary>
    internal class SqlDataAccess
    {
        // We store the connection string on the Configurations Files as a security measure.
        public String GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
       //this is how we load data to the DB 
        public List<T> LoadData <T,U> (string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();
                return rows;
            }
        }
        //this is how we save data to the DB 
        public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        // !!! we could use Transactions if we wanted to but the above basics will be fine.
    }
}