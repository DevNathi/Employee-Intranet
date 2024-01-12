using System;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Emp_Intranet_Api.DataAccess.InternalDataAccess
{
    /// <summary>
    /// In this class handles the SQL connection string using the SQL client
    /// We us Dapper to Map models as we will be passing generics as our parameters 
    /// WE will use Transactions to query the SQL for multiple tables 
    /// </summary>
    public class SqlDataAccess 
    {

        // We store the connection string on the Configurations Files as a security measure.
        public String GetConnectionString(string name)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        /// <summary>
        /// this is how we load data to the DB 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();
                return rows;
            }
        }
        /// <summary>
        /// this is how we save data to the DB 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionStringName"></param>
        public int SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var output = connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return output;
            }
        }

        private IDbConnection _connection;
        private IDbTransaction _transaction;

        //Start Transaction 
        //Open connection 
        public void StartTransaction(string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            IsClosed = false;
        }
        //Open connect/start transaction
        //load using transaction
        //save using transaction
        //Close connection/stop transtion method!!!
        //Dispose
        //Save Data Transaction 
        public void SaveDataTransaction<T>(string storedProcedure, T parameters)
        {

            _connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: _transaction);
        }

        //Load Data Transattion 
        public List<T> LoadDataTransaction<T, U>(string storedProcedure, U parameters)
        {
            List<T> rows = _connection.Query<T>(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure, transaction: _transaction).ToList();
            return rows;
        }

        private bool IsClosed = false;

 

        public void CommitTransation()
        {
            _transaction?.Commit();
            _connection?.Close();
            IsClosed = true;
        }

        public void RollBackTransaction()
        {
            _transaction.Rollback();
            _connection?.Close();
            IsClosed = true;

        }

        public void Dispose()
        {
            if (IsClosed == false)
            {
                try
                {
                    CommitTransation();
                }
                catch
                {

                    //TODO Log issue 
                }
            }

            _transaction = null;
            _connection = null;
        }

    }
}