using Dapper;
using HemsTask.Model.Models;
using System.Threading.Tasks;

namespace HemsTask.DataAccess.Repositories.IRepositories
{
    public interface IProductTypeRepository : ISPGenericRepository<ProductType>
    {
        Task<ProductType> GetProductTypeByCode(string procedureName, DynamicParameters param = null);

    }
}
