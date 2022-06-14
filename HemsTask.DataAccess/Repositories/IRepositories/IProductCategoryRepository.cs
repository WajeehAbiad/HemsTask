using Dapper;
using HemsTask.Model.Models;
using System.Threading.Tasks;

namespace HemsTask.DataAccess.Repositories.IRepositories
{
    public interface IProductCategoryRepository : ISPGenericRepository<ProductCategory>
    {
        Task<ProductCategory> GetProductCategoryByCode(string procedureName, DynamicParameters param = null);
    }
}
