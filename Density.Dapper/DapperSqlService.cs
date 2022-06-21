using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

namespace Density.Dapper
{
    public class DapperSqlService : SqlService
    {
        public DapperSqlService(IConnectionDescription connectionDescription) : base(connectionDescription) { }
        protected override int Execute(string connectionString, SqlModule module)
        {
            using (var conn = new SqlConnection(connectionString))
                return SqlMapper.Execute(conn, module.Command, param: module.Parameters, commandType: module.Type);
        }
        protected override T ExecuteScalar<T>(string connectionString, SqlModule module)
        {
            using (var conn = new SqlConnection(connectionString))
                return SqlMapper.ExecuteScalar<T>(conn, module.Command, param: module.Parameters, commandType: module.Type);
        }
        protected override IEnumerable<T> Query<T>(string connectionString, SqlModule module)
        {
            using (var conn = new SqlConnection(connectionString))
                return SqlMapper.Query<T>(conn, module.Command, param: module.Parameters, commandType: module.Type);
        }
        protected override T QueryFirst<T>(string connectionString, SqlModule module)
        {
            using (var conn = new SqlConnection(connectionString))
                return SqlMapper.QueryFirst<T>(conn, module.Command, param: module.Parameters, commandType: module.Type);
        }
        protected override T QueryFirstOrDefault<T>(string connectionString, SqlModule module)
        {
            using (var conn = new SqlConnection(connectionString))
                return SqlMapper.QueryFirstOrDefault<T>(conn, module.Command, param: module.Parameters, commandType: module.Type);
        }
    }
}
