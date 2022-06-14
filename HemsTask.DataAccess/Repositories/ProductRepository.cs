using Dapper;
using HemsTask.DataAccess.Repositories.IRepositories;
using HemsTask.Model.Models;
using System.Data;
using System.Threading.Tasks;

namespace HemsTask.DataAccess.Repositories
{
    public class ProductRepository : SPGenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IDbTransaction transaction) : base(transaction)
        {

        }

        public async Task<Product> GetProductByCode(string procedureName, DynamicParameters param = null)
        {
            return await Connection.QueryFirstOrDefaultAsync<Product>(procedureName, param, Transaction, null, System.Data.CommandType.StoredProcedure);
        }
    }
}
