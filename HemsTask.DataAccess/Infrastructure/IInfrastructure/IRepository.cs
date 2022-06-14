using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HemsTask.DataAccess.Infrastructure.IInfrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        T Get(Guid id);

        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        void Remove(Guid id);
        void Remove(T entity);
    }
}
