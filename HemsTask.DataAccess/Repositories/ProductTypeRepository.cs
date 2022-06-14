using Dapper;
using HemsTask.DataAccess.Repositories.IRepositories;
using HemsTask.Model.Models;
using System.Data;
using System.Threading.Tasks;

namespace HemsTask.DataAccess.Repositories
{
    public class ProductTypeRepository : SPGenericRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(IDbTransaction transaction) : base(transaction)
        {

        }

        public async Task<ProductType> GetProductTypeByCode(string procedureName, DynamicParameters param = null)
        {
            return await Connection.QueryFirstOrDefaultAsync<ProductType>(procedureName, param, Transaction, null, System.Data.CommandType.StoredProcedure);
        }
    }
}
