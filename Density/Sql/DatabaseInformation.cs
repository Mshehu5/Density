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
        /// 
        /// </summary>
        public string CurrentLanguage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan Timeout { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan LoadBalanceTimeout { get; set; }
        /// <summary>
        /// 
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
