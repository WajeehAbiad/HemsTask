using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

using HemsTask.DataAccess.Infrastructure.IInfrastructure;

namespace HemsTask.DataAccess.Infrastructure
{
    public class SP_Call : ISP_Call
    {
        private readonly DbContext _db;
        private static string ConnectionString = "";

        public SP_Call(DbContext db)
        {
            _db = db;
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }

        public IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public T ReturnRecord<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                return sqlCon.QuerySingle<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public T ExecuteReturnScaler<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
