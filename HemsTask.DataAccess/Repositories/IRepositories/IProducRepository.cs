using Dapper;
using HemsTask.Model.Models;
using System.Threading.Tasks;

namespace HemsTask.DataAccess.Repositories.IRepositories
{
    public interface IProductRepository : ISPGenericRepository<Product>
    {
        Task<Product> GetProductByCode(string procedureName, DynamicParameters param = null);

    }
}
