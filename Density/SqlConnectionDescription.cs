using System;

namespace Density
{
    public class SqlConnectionDescription : IConnectionDescription
    {
        public bool UseIntegratedSecurity { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public TimeSpan? Timeout { get; set; }
    }
}
