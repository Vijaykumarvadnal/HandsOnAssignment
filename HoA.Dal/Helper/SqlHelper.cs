using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DapperExtensions;
using Microsoft.Extensions.Configuration;

namespace HoA.Dal.Helper
{
    public class SqlHelper
    {
        protected string ConnectionString = "Server=.;Database=HoA;Integrated Security=True;";
        public bool Insert<T>(T parameter) where T : class
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                sqlConnection.Insert(parameter);
                sqlConnection.Close();
                return true;
            }
        }
        public int InsertWithReturnId<T>(T parameter) where T : class
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var recordId = sqlConnection.Insert(parameter);
                sqlConnection.Close();
                return recordId;
            }
        }
        public bool Update<T>(T parameter) where T : class
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                sqlConnection.Update(parameter);
                sqlConnection.Close();
                return true;
            }
        }
        public IList<T> GetAll<T>() where T : class
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var result = sqlConnection.GetList<T>();
                sqlConnection.Close();
                return result.ToList();
            }
        }
        public T Find<T>(PredicateGroup predicate) where T : class
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var result = sqlConnection.GetList<T>(predicate).FirstOrDefault();
                sqlConnection.Close();
                return result;
            }
        }
        public bool Delete<T>(PredicateGroup predicate) where T : class
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                sqlConnection.Delete<T>(predicate);
                sqlConnection.Close();
                return true;
            }
        }
        public IEnumerable<T> QuerySP<T>(string storedProcedure, dynamic param = null,
            dynamic outParam = null, SqlTransaction transaction = null,
            bool buffered = true, int? commandTimeout = null) where T : class
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            var output = connection.Query<T>(storedProcedure, param: (object)param,
            transaction: transaction, buffered: buffered, commandTimeout: commandTimeout,
            commandType: CommandType.StoredProcedure);
            return output;
        }
        private void CombineParameters(ref dynamic param, dynamic outParam = null)
        {
            if (outParam != null)
            {
                if (param != null)
                {
                    param = new DynamicParameters(param);
                    ((DynamicParameters)param).AddDynamicParams(outParam);
                }
                else
                {
                    param = outParam;
                }
            }
        }
        private int ConnectionTimeout { get; set; }
    }
}
