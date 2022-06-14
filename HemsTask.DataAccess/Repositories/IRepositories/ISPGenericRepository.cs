using System.Threading.Tasks;
using System.Collections.Generic;
using Dapper;

namespace HemsTask.DataAccess.Repositories.IRepositories
{
    //public interface ISPGenericRepository<T> where T : class, IDisposable
    public interface ISPGenericRepository<T> where T : class
        //public interface ISPGenericRepository : IDisposable
    {
        //void Add(string procedureName, DynamicParameters param = null);
        //Task<T> Add(string procedureName, DynamicParameters param = null);
        Task<T> Add(string procedureName, DynamicParameters param = null);
        Task<int> AddBulk(string procedureName, object paramBulk = null);

        Task<IEnumerable<T>> Get(string procedureName, DynamicParameters param = null);
        Task<T> GetById(string procedureName, DynamicParameters param = null);

        Task<IEnumerable<TResult>> GetGet<TResult>(string procedureName, DynamicParameters param = null);

        Task<T> Update(string procedureName, DynamicParameters param = null);
        Task<int> UpdateBulk(string procedureName, object paramBulk = null);
        Task<int> UpdateMany(string procedureName, DynamicParameters param = null);

        Task<T> Delete(string procedureName, DynamicParameters param = null);

        Task<int> DeleteMany(string procedureName, DynamicParameters param = null);
    }
}
