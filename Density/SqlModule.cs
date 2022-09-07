using System.Collections.Generic;
using System.Data;

namespace Density
{
    /// <summary>
    /// A <see cref="SqlModule"/> capable of representing queries, stored procedures, and functions.
    /// </summary>
    public abstract class SqlModule
    {

        #region Properties

        /// <summary>
        /// The command this module is representing.
        /// </summary>
        public string Command { get; private set; }
        /// <summary>
        /// The type of command this module is for.
        /// </summary>
        public CommandType Type { get; private set; }
        /// <summary>
        /// The parameters for this module, if any.
        /// </summary>
        public IEnumerable<SqlParameter> Parameters { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="SqlModule"/> with the specified command and <see cref="CommandType"/>.
        /// </summary>
        /// <param name="command">The command this module is representing.</param>
        /// <param name="type">The type of command this module is for.</param>
        public SqlModule(string command, CommandType type)
        {
            Command = command;
            Type = type;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Adds the specified parameter to the dynamic parameters of the module.
        /// </summary>
        /// <typeparam name="TParameter">The type of the parameter.</typeparam>
        /// <param name="name">The name of the parameter expected by the command.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <param name="type">The type expected in the database for this parameter.</param>
        /// <param name="direction">The direction of the parameter in the module.</param>
        /// <param name="size">The size of the parameter as expected by the database.</param>
        /// <param name="precision">The precision of the parameter.</param>
        /// <param name="scale">The scale of the parameter.</param>
        protected virtual void AddParameter<TParameter>(string name, TParameter value = default,
                                                        DbType? type = null, ParameterDirection? direction = null,
                                                        int? size = null, byte? precision = null, byte? scale = null)
        {
            if (Parameters == null)
                Parameters = new List<SqlParameter>();

            (Parameters as List<SqlParameter>).Add(new SqlParameter(name, value, type, size, precision, scale, direction));
        }

        #endregion

    }
}
