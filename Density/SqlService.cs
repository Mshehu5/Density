using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Density
{
    /// <summary>
    /// Represents a <see cref="SqlService"/> for executing <see cref="SqlModule"/> instances.
    /// </summary>
    public abstract class SqlService
    {

        #region Properties

        public IConnectionDescription ConnectionDescription { get; private set; }

        #endregion

        #region Constructor

        public SqlService(IConnectionDescription connectionDescription) =>
            ConnectionDescription = connectionDescription;

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public int Execute(SqlModule module)
        {
            BuildConnectionString(out string connectionString);
            return Execute(connectionString, module);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="module"></param>
        /// <returns></returns>
        public T ExecuteScalar<T>(SqlModule module)
        {
            BuildConnectionString(out string connectionString);
            return ExecuteScalar<T>(connectionString, module);
        }
        /// <summary>
        /// Executes the specified module as a query on the active database.
        /// </summary>
        /// <typeparam name="T">The expected return type of the module.</typeparam>
        /// <param name="module">The module to execute.</param>
        /// <returns>Returns the queried data.</returns>
        public IEnumerable<T> Query<T>(SqlModule module)
        {
            BuildConnectionString(out string connectionString);
            return Query<T>(connectionString, module);
        }
        /// <summary>
        /// Executes the specified module as a query on the active database and returns the first record.
        /// </summary>
        /// <typeparam name="T">The expected return type of the module.</typeparam>
        /// <param name="module">The module to execute.</param>
        /// <returns>Returns the queried data.</returns>
        public T QueryFirst<T>(SqlModule module)
        {
            BuildConnectionString(out string connectionString);
            return QueryFirst<T>(connectionString, module);
        }
        /// <summary>
        /// Executes the specified module as a query on the active database and returns the first record.
        /// </summary>
        /// <typeparam name="T">The expected return type of the module.</typeparam>
        /// <param name="module">The module to execute.</param>
        /// <returns>Returns the queried data.</returns>
        public T QueryFirstOrDefault<T>(SqlModule module)
        {
            BuildConnectionString(out string connectionString);
            return QueryFirstOrDefault<T>(connectionString, module);
        }

        #endregion

        #region Protected Methods

        protected virtual void BuildConnectionString(out string connectionString)
        {
            // Validate the provided connection description.
            if (ConnectionDescription == null)
                throw new ArgumentNullException("A connection description is required to establish a connection with SQL.");

            // Validate the provided server.
            string server = ConnectionDescription.Server ?? string.Empty;
            if (string.IsNullOrWhiteSpace(server))
                throw new ArgumentException($"A server is required to establish a connection with SQL.");

            // Validate the provided database.
            string database = ConnectionDescription.Database ?? string.Empty;
            if (string.IsNullOrWhiteSpace(database))
                throw new ArgumentException($"A database is required to establish a connection with SQL.");

            // Validate the provided username.
            string username = ConnectionDescription.Username ?? string.Empty;
            if (string.IsNullOrWhiteSpace(username) && !ConnectionDescription.UseIntegratedSecurity)
                throw new ArgumentException($"A username is required to establish a connection with SQL unless integrated security is set to `true`.");

            // Validate the provided password.
            string password = ConnectionDescription.Password ?? string.Empty;
            if (string.IsNullOrWhiteSpace(password) && !ConnectionDescription.UseIntegratedSecurity)
                throw new ArgumentException($"A password is required to establish a connection with SQL unless integrated security is set to `true`.");

            // Build the connection string.
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                InitialCatalog = database,
                DataSource = server,
                UserID = username,
                Password = password,
                IntegratedSecurity = ConnectionDescription.UseIntegratedSecurity,
                ConnectTimeout = checked((int?)ConnectionDescription.Timeout?.TotalSeconds) ?? 30
            };

            // Set the out parameter.
            connectionString = connectionStringBuilder.ConnectionString;
        }

        #endregion

        #region Abstract Methods

        protected abstract int Execute(string connectionString, SqlModule module);
        protected abstract T ExecuteScalar<T>(string connectionString, SqlModule module);
        protected abstract IEnumerable<T> Query<T>(string connectionString, SqlModule module);
        protected abstract T QueryFirst<T>(string connectionString, SqlModule module);
        protected abstract T QueryFirstOrDefault<T>(string connectionString, SqlModule module);

        #endregion

    }
}
