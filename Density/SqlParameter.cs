using System.Data;

namespace Density
{
    /// <summary>
    /// Represents a <see cref="SqlParameter"/> for interactions via query, stored procedure, or function.
    /// </summary>
    public class SqlParameter
    {

        #region Properties

        /// <summary>
        /// The name of the parameter.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The value of the parameter.
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// The type of the parameter.
        /// </summary>
        public DbType? Type { get; set; }
        /// <summary>
        /// The size of the parameter.
        /// </summary>
        public int? Size { get; set; }
        /// <summary>
        /// The precision of the parameter.
        /// </summary>
        public byte? Precision { get; set; }
        /// <summary>
        /// The scale of the parameter.
        /// </summary>
        public byte? Scale { get; set; }
        /// <summary>
        /// The direction of the parameter.
        /// </summary>
        public ParameterDirection? Direction { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="SqlParameter"/> with the specified name and value, along with any additionally supplied information about the parameter.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <param name="type">The type of the parameter.</param>
        /// <param name="size">The size of the parameter.</param>
        /// <param name="precision">The precision of the parameter.</param>
        /// <param name="scale">The scale of the parameter.</param>
        /// <param name="direction">The direction of the parameter.</param>
        public SqlParameter(string name, object value,
                            DbType? type = null,
                            int? size = null,
                            byte? precision = null,
                            byte? scale = null,
                            ParameterDirection? direction = ParameterDirection.Input)
        {
            Name = name;
            Value = value;
            Type = type;
            Size = size;
            Precision = precision;
            Scale = scale;
            Direction = direction;
        }

        #endregion

    }
}
