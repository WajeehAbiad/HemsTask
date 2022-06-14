using System;
using HemsTask.DataAccess.Infrastructure.IInfrastructure;
using Microsoft.EntityFrameworkCore;
using HemsTask.DataAccess.Repositories.IRepositories;
using HemsTask.DataAccess.Repositories;
using System.Data.SqlClient;
using System.Data;

namespace HemsTask.DataAccess.Infrastructure
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _dbContext;
		private IDbConnection _connection;
		private IDbTransaction _transaction;
		private bool _disposed;

		private IProductCategoryRepository _productCategories;
		private IProductTypeRepository _productTypes;
		private IProductRepository _products;

		public UnitOfWork(AppDbContext dbContext)
		{
			_dbContext = dbContext;
			_connection = new SqlConnection(_dbContext.Database.GetDbConnection().ConnectionString);
			_connection.Open();
			_transaction = _connection.BeginTransaction();
		}

		public IProductCategoryRepository ProductCategories
		{
			get { return _productCategories ??= new ProductCategoryRepository(_transaction); }
		}

		public IProductTypeRepository ProductTypes
		{
			get { return _productTypes ??= new ProductTypeRepository(_transaction); }
		}

		public IProductRepository Products
		{
			get { return _products ??= new ProductRepository(_transaction); }
		}

		public void Commit()
		{
			try
			{
				_transaction.Commit();
			}
			catch
			{
				_transaction.Rollback();
				throw;
			}
			finally
			{
				_transaction.Dispose();
				_transaction = _connection.BeginTransaction();
				ResetRepositories();
			}
		}

		public void Rollback()
		{
			try
			{
				_transaction.Rollback();
			}
			catch
			{
				//_transaction.Rollback();
				throw;
			}
			finally
			{
				_transaction.Dispose();
				_transaction = _connection.BeginTransaction();
				ResetRepositories();
			}
		}

		private void ResetRepositories()
		{
			_productCategories = null;
			_productTypes = null;
			_products = null;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					if (_transaction != null)
					{
						_transaction.Dispose();
						_transaction = null;
					}
					if (_connection != null)
					{
						_connection.Dispose();
						_connection = null;
					}
				}
				_disposed = true;
			}
		}

		~UnitOfWork()
		{
			Dispose(false);
		}
	}
}