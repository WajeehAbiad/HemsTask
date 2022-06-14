using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using HemsTask.DataAccess.Repositories.IRepositories;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using FastMember;
using HemsTask.DataAccess;

namespace HemsTask.DataAccess.Repositories
{
	public class SPGenericRepository<T> : ISPGenericRepository<T> where T : class
		//public class SPGenericRepository : ISPGenericRepository
	{
		//private readonly DbContext _ctxt;

		//private static string ConnectionString = "";
		//private readonly DynamicParameters _params;

		protected IDbTransaction Transaction { get; private set; }
		protected IDbConnection Connection { get { return Transaction.Connection; } }

		public SPGenericRepository(IDbTransaction transaction = null)
		{
			Transaction = transaction;
		}

		public async Task<T> Add(string procedureName, DynamicParameters param = null)
		{
			return await Connection.QuerySingleAsync<T>(procedureName, param, Transaction, null, System.Data.CommandType.StoredProcedure);
		}

		public async Task<int> AddBulk(string procedureName, object paramBulk = null)
		{
			return await Connection.ExecuteAsync(procedureName, paramBulk, Transaction, null, System.Data.CommandType.StoredProcedure);
		}

		public async Task<IEnumerable<T>> Get(string procedureName, DynamicParameters param = null)
		{
			return await Connection.QueryAsync<T>(procedureName, param, Transaction, null, System.Data.CommandType.StoredProcedure);
		}

		public async Task<T> GetById(string procedureName, DynamicParameters param = null)
		{
			return await Connection.QueryFirstOrDefaultAsync<T>(procedureName, param, Transaction, null, System.Data.CommandType.StoredProcedure);
		}

		public async Task<IEnumerable<TResult>> GetGet<TResult>(string procedureName, DynamicParameters param = null)
		{
			return await Connection.QueryAsync<TResult>(procedureName, param, Transaction, null, System.Data.CommandType.StoredProcedure);
		}

		public async Task<T> Update(string procedureName, DynamicParameters param = null)
		{
			return await Connection.QuerySingleAsync<T>(procedureName, param, Transaction, null, System.Data.CommandType.StoredProcedure);
		}

		public async Task<int> UpdateBulk(string procedureName, object paramBulk = null)
		{
			return await Connection.ExecuteAsync(procedureName, paramBulk, Transaction, null, System.Data.CommandType.StoredProcedure);
		}

		public async Task<int> UpdateMany(string procedureName, DynamicParameters param = null)
		{
			return await Connection.ExecuteAsync(procedureName, param, Transaction, null, System.Data.CommandType.StoredProcedure);
		}

		public async Task<T> Delete(string procedureName, DynamicParameters param = null)
		{
			return await Connection.QuerySingleAsync<T>(procedureName, param, Transaction, null, System.Data.CommandType.StoredProcedure);
		}

		public async Task<int> DeleteMany(string procedureName, DynamicParameters param = null)
		{
			return await Connection.ExecuteAsync(procedureName, param, Transaction, null, System.Data.CommandType.StoredProcedure);
		}
	}
}
