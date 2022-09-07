using System.Collections.Generic;

namespace Density
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Endpoint
    {

        #region Fields

        private List<EndpointParameter> _parameters;

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyList<EndpointParameter> Parameters => _parameters.AsReadOnly();

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public Endpoint() => _parameters = new List<EndpointParameter>();

        #endregion

        #region Protected Methods

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected void AddParameter<T>(string key, T value) => _parameters.Add(new EndpointParameter(key, value));

        #endregion

    }
}
