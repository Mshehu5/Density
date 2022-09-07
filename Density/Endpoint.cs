using System.Collections.Generic;

namespace Density
{
    public abstract class Endpoint
    {

        #region Fields

        private List<EndpointParameter> _parameters;

        #endregion

        #region Properties

        public IReadOnlyList<EndpointParameter> Parameters => _parameters.AsReadOnly();

        #endregion

        #region Constructor

        public Endpoint() => _parameters = new List<EndpointParameter>();

        #endregion

        #region Protected Methods

        protected void AddParameter<T>(string key, T value) => _parameters.Add(new EndpointParameter(key, value));

        #endregion

    }
}
