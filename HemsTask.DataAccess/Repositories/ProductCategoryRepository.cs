using Dapper;
using HemsTask.DataAccess.Repositories.IRepositories;
using HemsTask.Model.Models;
using System.Data;
using System.Threading.Tasks;

namespace HemsTask.DataAccess.Repositories
{
    public class ProductCategoryRepository : SPGenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbTransaction transaction) : base(transaction)
        {

        }

        public async Task<ProductCategory> GetProductCategoryByCode(string procedureName, DynamicParameters param = null)
        {
            return await Connection.QueryFirstOrDefaultAsync<ProductCategory>(procedureName, param, Transaction, null, System.Data.CommandType.StoredProcedure);
        }
    }
}
