using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HemsTask.DataAccess.Infrastructure.IInfrastructure
{
    public interface ISP_Call : IDisposable 
    {
        IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null);

        T ReturnRecord<T>(string procedureName, DynamicParameters param = null);

        void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null);

        T ExecuteReturnScaler<T>(string procedureName, DynamicParameters param = null);
    }
}
