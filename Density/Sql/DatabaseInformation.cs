using System;
using System.Data.SqlClient;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Density.Sql
{
    /// <summary>
    /// 
    /// </summary>
    public class DatabaseInformation
    {
        /// <summary>
        /// 
        /// </summary>
        public bool UseIntegratedSecurity { get; set; }
        /// <summary>
        /// Gets or sets a Boolean value that indicates whether User ID and Password are specified in the connection (when false) or whether the current Windows account credentials are used for authentication (when true).
        /// </summary>
        public string CurrentLanguage { get; set; }
        /// <summary>
        /// Gets or sets the SQL Server Language record name
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// Gets or sets the name or network address of the instance of SQL Server to connect to.
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// Gets or sets the name of the database associated with the connection.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the user ID to be used when connecting to SQL Server.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the password for the SQL Server account.
        /// </summary>
        public TimeSpan Timeout { get; set; }
        /// <summary>
        /// Gets or sets the length of time (in seconds) to wait for a connection to the server before terminating the attempt and generating an error.
        /// </summary>
        public TimeSpan LoadBalanceTimeout { get; set; }
        /// <summary>
        /// Gets or sets the minimum time, in seconds, for the connection to live in the connection pool before being destroyed.
        /// </summary>
        [JsonIgnore] [XmlIgnore]
        public string ConnectionString
        {
            get
            {
                var connectionStringBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = Server,
                    InitialCatalog = Database,
                    UserID = Username,
                    Password = Password,
                    IntegratedSecurity = UseIntegratedSecurity,
                    ConnectTimeout = checked((int)Timeout.TotalSeconds),
                    LoadBalanceTimeout = checked((int)LoadBalanceTimeout.TotalMilliseconds),
                    CurrentLanguage = CurrentLanguage
                };
                return connectionStringBuilder.ConnectionString;
            }
        }
    }
}
