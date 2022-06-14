using AutoMapper;
using HemsTask.DataAccess.Repositories.IRepositories;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemsTask.DataAccess.Infrastructure.IInfrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IProductCategoryRepository ProductCategories { get; }
        IProductTypeRepository ProductTypes { get; }
        IProductRepository Products { get; }

        void Commit();
        void Rollback();
    }
}
