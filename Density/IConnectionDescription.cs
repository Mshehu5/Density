using System;

namespace Density
{
    public interface IConnectionDescription
    {

        #region Properties

        /// <summary>
        /// Designates whether or not integrated security should be utilized, where applicable.
        /// </summary>
        bool UseIntegratedSecurity { get; set; }
        /// <summary>
        /// The server where the database is hosted.
        /// </summary>
        string Server { get; set; }
        /// <summary>
        /// The name of the database to connect to.
        /// </summary>
        string Database { get; set; }
        /// <summary>
        /// The username that should be used to authenticate to the database.
        /// </summary>
        string Username { get; set; }
        /// <summary>
        /// The password used to authenticate to the database.
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// The length of time connections are allowed to run without a response before timing out.
        /// </summary>
        TimeSpan? Timeout { get; set; }

        #endregion

    }
}
